using System;

namespace BLL.DTOs;

public class ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Slug { get; set; }
    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public decimal OldPrice { get; set; }
    public string? MainImage { get; set; }
    public int StockQuantity { get; set; }
    public bool IsHot { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsBestSeller { get; set; }
    public string? CategoryName { get; set; }
    public string? BrandName { get; set; }
    public decimal DiscountPercentage => OldPrice > 0 ? Math.Round(((OldPrice - Price) / OldPrice) * 100, 0) : 0;
}
