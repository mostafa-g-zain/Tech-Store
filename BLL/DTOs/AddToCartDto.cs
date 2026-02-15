using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTOs;

public class AddToCartDto
{
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Product ID must be greater than 0")]
    public int ProductId { get; set; }
    
    [Required]
    [Range(1, 100, ErrorMessage = "Quantity must be between 1 and 100")]
    public int Quantity { get; set; } = 1;
}
