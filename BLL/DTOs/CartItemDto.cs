using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTOs;

public class CartItemDto
{
    public int Id { get; set; }
    public int CartId { get; set; }
    public int ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public DateTime AddedAt { get; set; }

    // Product details for display
    public string ProductName { get; set; } = string.Empty;
    public string? ProductSlug { get; set; }
    public string? ProductImage { get; set; }
    public int StockQuantity { get; set; }

    // Calculated props
    public decimal LineTotal => Quantity * UnitPrice;
    public bool IsInStock => StockQuantity > 0;
    public bool IsQuantityAvailable => StockQuantity >= Quantity;
}
