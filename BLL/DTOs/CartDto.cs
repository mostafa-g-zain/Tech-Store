using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.DTOs;

public class CartDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public List<CartItemDto> Items { get; set; } = new();

    // Calculated props
    public int TotalItems => Items.Sum(i => i.Quantity);
    public decimal Subtotal => Items.Sum(i => i.Quantity * i.UnitPrice);
    public decimal Tax => Subtotal * 0.14m; // 14% tax
    public decimal Total => Subtotal + Tax;
}
