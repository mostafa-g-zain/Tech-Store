using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BLL.DTOs;
using BLL.Interfaces;
using BLL.Mappings;

using DAL.Contexts;
using DAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BLL.Services;

public class CartService : ICartService
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<CartService> _logger;

    public CartService(ApplicationDbContext context, ILogger<CartService> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<CartDto> AddToCartAsync(int userId, AddToCartDto dto)
    {
        _logger.LogInformation($"Adding product {dto.ProductId} (Quantity: {dto.Quantity}) to cart for user {userId}");

        // Validate product exists and has sufficient stock
        var product = await _context.Products
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Id == dto.ProductId);

        if (product == null)
        {
            _logger.LogWarning($"Product {dto.ProductId} not found for user {userId}");
            throw new InvalidOperationException($"Product with ID {dto.ProductId} not found.");
        }

        if (product.StockQuantity < dto.Quantity)
        {
            _logger.LogWarning($"Insufficient stock for product {dto.ProductId}. Available: {product.StockQuantity}, Requested: {dto.Quantity}");
            throw new InvalidOperationException($"Insufficient stock. Only {product.StockQuantity} units available.");
        }

        try
        {
            // Get or create cart
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId,
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CartItems = new List<CartItem>()
                };
                _context.Carts.Add(cart);
            }

            // Check if product already in cart
            var existingCartItem = cart.CartItems
                .FirstOrDefault(ci => ci.ProductId == dto.ProductId);

            if (existingCartItem != null)
            {
                var newQuantity = existingCartItem.Quantity + dto.Quantity;

                if (product.StockQuantity < newQuantity)
                {
                    _logger.LogWarning($"Insufficient stock for product {dto.ProductId}. Available: {product.StockQuantity}, Requested total: {newQuantity}");
                    throw new InvalidOperationException($"Insufficient stock. Only {product.StockQuantity} units available.");
                }

                existingCartItem.Quantity = newQuantity;
            }
            else
            {
                var newCartItem = new CartItem
                {
                    ProductId = dto.ProductId,
                    Quantity = dto.Quantity,
                    UnitPrice = product.Price,
                    AddedAt = DateTime.UtcNow
                };
                cart.CartItems.Add(newCartItem);
            }

            cart.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            // Return updated cart
            var updatedCart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return updatedCart!.ToCartDto();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, $"Database error adding product {dto.ProductId} to cart for user {userId}");
            throw new InvalidOperationException("Failed to update cart. Please try again.", ex);
        }
        catch (Exception ex) when (ex is not InvalidOperationException)
        {
            _logger.LogError(ex, $"Unexpected error adding product {dto.ProductId} to cart for user {userId}");
            throw;
        }
    }

    public async Task<bool> ClearCartAsync(int userId)
    {
        _logger.LogInformation($"Clearing cart for user {userId}");

        try
        {
            var cart = await _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            if (cart == null)
            {
                _logger.LogWarning($"No cart found for user {userId} when attempting to clear");
                return false;
            }

            var itemCount = cart.CartItems.Count;
            _context.CartItems.RemoveRange(cart.CartItems);
            cart.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            _logger.LogInformation($"Cleared {itemCount} items from cart for user {userId}");
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error clearing cart for user {userId}");
            throw;
        }
    }

    public async Task<CartDto?> GetCartByUserIdAsync(int userId)
    {
        try
        {
            var cart = await _context.Carts
                .AsNoTracking()
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return cart?.ToCartDto();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error retrieving cart for user {userId}");
            throw;
        }
    }

    public async Task<int> GetCartItemCountAsync(int userId)
    {
        try
        {
            return await _context.CartItems
                .AsNoTracking()
                .Where(ci => ci.Cart.UserId == userId)
                .SumAsync(ci => ci.Quantity);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error getting cart item count for user {userId}");
            throw;
        }
    }

    public async Task<bool> RemoveCartItemAsync(int userId, int cartItemId)
    {
        _logger.LogInformation($"Removing cart item {cartItemId} for user {userId}");

        try
        {
            var cartItem = await _context.CartItems
                .Include(ci => ci.Cart)
                .FirstOrDefaultAsync(ci => ci.Id == cartItemId && ci.Cart.UserId == userId);

            if (cartItem == null)
            {
                _logger.LogWarning($"Cart item {cartItemId} not found for user {userId}");
                return false;
            }

            _context.CartItems.Remove(cartItem);
            cartItem.Cart.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Error removing cart item {cartItemId} for user {userId}");
            throw;
        }
    }

    public async Task<CartDto> UpdateCartItemAsync(int userId, UpdateCartItemDto dto)
    {
        _logger.LogInformation($"Updating cart item {dto.CartItemId} to quantity {dto.Quantity} for user {userId}");

        var cartItem = await _context.CartItems
            .Include(ci => ci.Cart)
            .Include(ci => ci.Product)
            .FirstOrDefaultAsync(ci => ci.Id == dto.CartItemId && ci.Cart.UserId == userId);

        if (cartItem == null)
        {
            _logger.LogWarning($"Cart item {dto.CartItemId} not found for user {userId}");
            throw new InvalidOperationException($"Cart item with ID {dto.CartItemId} not found.");
        }

        if (cartItem.Product.StockQuantity < dto.Quantity)
        {
            _logger.LogWarning($"Insufficient stock for product {cartItem.ProductId}. Available: {cartItem.Product.StockQuantity}, Requested: {dto.Quantity}");
            throw new InvalidOperationException($"Insufficient stock. Only {cartItem.Product.StockQuantity} units available.");
        }

        try
        {
            cartItem.Quantity = dto.Quantity;
            cartItem.Cart.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            // Return updated cart
            var updatedCart = await _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Product)
                .FirstOrDefaultAsync(c => c.UserId == userId);

            return updatedCart!.ToCartDto();
        }
        catch (DbUpdateException ex)
        {
            _logger.LogError(ex, $"Database error updating cart item {dto.CartItemId} for user {userId}");
            throw new InvalidOperationException("Failed to update cart item. Please try again.", ex);
        }
        catch (Exception ex) when (ex is not InvalidOperationException)
        {
            _logger.LogError(ex, $"Unexpected error updating cart item {dto.CartItemId} for user {userId}");
            throw;
        }
    }
}
