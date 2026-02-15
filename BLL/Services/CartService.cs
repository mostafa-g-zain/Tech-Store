using System;
using System.Collections.Generic;
using System.Text;

using BLL.DTOs;
using BLL.Interfaces;

using DAL.Contexts;

namespace BLL.Services;

public class CartService : ICartService
{
    private readonly ApplicationDbContext _context;
    public CartService(ApplicationDbContext context)
    {
        _context = context;
    }
    public Task<CartDto> AddToCartAsync(int userId, AddToCartDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ClearCartAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<CartDto?> GetCartByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<int> GetCartItemCountAsync(int userId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveCartItemAsync(int userId, int cartItemId)
    {
        throw new NotImplementedException();
    }

    public Task<CartDto> UpdateCartItemAsync(int userId, UpdateCartItemDto dto)
    {
        throw new NotImplementedException();
    }
}
