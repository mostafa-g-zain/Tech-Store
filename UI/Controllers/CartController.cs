using System.Security.Claims;

using BLL.Common;
using BLL.DTOs;
using BLL.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers;

[Authorize(Roles = AppRoles.Customer)]
public class CartController : Controller
{
    private readonly ICartService _cartService;

    public CartController(ICartService cartService)
    {
        _cartService = cartService;
    }

    private int GetUserId() =>
        int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

    // GET: /Cart
    public async Task<IActionResult> Index()
    {
        var cart = await _cartService.GetCartByUserIdAsync(GetUserId());
        return View(cart ?? new CartDto());
    }

    // POST: /Cart/Add
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Add(int productId, int quantity = 1)
    {
        try
        {
            var dto = new AddToCartDto { ProductId = productId, Quantity = quantity };
            await _cartService.AddToCartAsync(GetUserId(), dto);
            TempData["CartMessage"] = "Product added to cart!";
        }
        catch (InvalidOperationException ex)
        {
            TempData["CartError"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }

    // POST: /Cart/AddAjax
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> AddAjax([FromBody] AddToCartDto dto)
    {
        try
        {
            var cart = await _cartService.AddToCartAsync(GetUserId(), dto);
            return Json(new { success = true, message = "Product added to cart!", totalItems = cart.TotalItems });
        }
        catch (InvalidOperationException ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }

    // POST: /Cart/UpdateQuantity
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateQuantity(int cartItemId, int quantity)
    {
        try
        {
            var dto = new UpdateCartItemDto { CartItemId = cartItemId, Quantity = quantity };
            await _cartService.UpdateCartItemAsync(GetUserId(), dto);
        }
        catch (InvalidOperationException ex)
        {
            TempData["CartError"] = ex.Message;
        }

        return RedirectToAction(nameof(Index));
    }

    // POST: /Cart/UpdateQuantityAjax
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateQuantityAjax([FromBody] UpdateCartItemDto dto)
    {
        try
        {
            var cart = await _cartService.UpdateCartItemAsync(GetUserId(), dto);
            var item = cart.Items.FirstOrDefault(i => i.Id == dto.CartItemId);
            return Json(new
            {
                success = true,
                lineTotal = item?.LineTotal ?? 0,
                subtotal = cart.Subtotal,
                tax = cart.Tax,
                total = cart.Total,
                totalItems = cart.TotalItems
            });
        }
        catch (InvalidOperationException ex)
        {
            return Json(new { success = false, message = ex.Message });
        }
    }

    // POST: /Cart/Remove
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Remove(int cartItemId)
    {
        await _cartService.RemoveCartItemAsync(GetUserId(), cartItemId);
        TempData["CartMessage"] = "Item removed from cart.";
        return RedirectToAction(nameof(Index));
    }

    // POST: /Cart/RemoveAjax
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RemoveAjax([FromBody] RemoveCartItemRequest request)
    {
        var result = await _cartService.RemoveCartItemAsync(GetUserId(), request.CartItemId);
        if (!result)
            return Json(new { success = false, message = "Item not found." });

        var cart = await _cartService.GetCartByUserIdAsync(GetUserId());
        return Json(new
        {
            success = true,
            subtotal = cart?.Subtotal ?? 0,
            tax = cart?.Tax ?? 0,
            total = cart?.Total ?? 0,
            totalItems = cart?.TotalItems ?? 0
        });
    }

    // POST: /Cart/Clear
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Clear()
    {
        await _cartService.ClearCartAsync(GetUserId());
        TempData["CartMessage"] = "Cart cleared.";
        return RedirectToAction(nameof(Index));
    }

    // GET: /Cart/GetCartCount
    [HttpGet]
    public async Task<IActionResult> GetCartCount()
    {
        var count = await _cartService.GetCartItemCountAsync(GetUserId());
        return Json(new { count });
    }

    public record RemoveCartItemRequest(int CartItemId);
}
