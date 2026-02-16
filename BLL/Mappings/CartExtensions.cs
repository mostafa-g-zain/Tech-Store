using BLL.DTOs;

using DAL.Entities;

namespace BLL.Mappings;

public static class CartExtensions
{
    public static CartDto ToCartDto(this Cart cart)
    {
        if (cart == null)
            return null;

        return new CartDto
        {
            Id = cart.Id,
            UserId = cart.UserId,
            CreatedAt = cart.CreatedAt,
            UpdatedAt = cart.UpdatedAt,
            Items = cart.CartItems.Select(ci => ci.ToCartItemDto()).ToList()
        };
    }

    public static CartItemDto ToCartItemDto(this CartItem cartItem)
    {
        if (cartItem == null)
            return null;

        return new CartItemDto
        {
            Id = cartItem.Id,
            CartId = cartItem.CartId,
            ProductId = cartItem.ProductId,
            Quantity = cartItem.Quantity,
            UnitPrice = cartItem.UnitPrice,
            AddedAt = cartItem.AddedAt,
            ProductName = cartItem.Product?.Name ?? string.Empty,
            ProductSlug = cartItem.Product?.Slug,
            ProductImage = cartItem.Product?.MainImage,
            StockQuantity = cartItem.Product?.StockQuantity ?? 0
        };
    }
}
