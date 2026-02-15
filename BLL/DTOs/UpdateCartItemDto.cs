using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs;

public class UpdateCartItemDto
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Cart item ID must be greater than 0")]
    public int CartItemId { get; set; }
    
    [Required]
    [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
    public int Quantity { get; set; }
}
