using System.Collections.Generic;

namespace BLL.DTOs;

public class ProductDetailsDto : ProductDto
{
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public List<ProductImageDto> Images { get; set; } = new();
    public List<SpecificationDto> Specifications { get; set; } = new();
    public List<ReviewDto> Reviews { get; set; } = new();
    public double AverageRating { get; set; }
    public int ReviewCount { get; set; }
}
