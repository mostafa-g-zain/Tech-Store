using System;
using System.Collections.Generic;
using System.Text;

using BLL.DTOs;

namespace BLL.Interfaces;

public interface ICartService
{
    // 1. Retrieve user's cart with all items and calculated totals
    Task<CartDto?> GetCartByUserIdAsync(int userId);

    // 2. Add product to cart (or increment if already exists)
    Task<CartDto> AddToCartAsync(int userId, AddToCartDto dto);

    // 3. Update quantity of existing cart item
    Task<CartDto> UpdateCartItemAsync(int userId, UpdateCartItemDto dto);

    // 4. Remove specific item from cart
    Task<bool> RemoveCartItemAsync(int userId, int cartItemId);

    // 5. Clear all items from cart
    Task<bool> ClearCartAsync(int userId);

    // 6. Get total item count (for UI badge)
    Task<int> GetCartItemCountAsync(int userId);
}
