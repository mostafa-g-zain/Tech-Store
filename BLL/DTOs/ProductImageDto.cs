namespace BLL.DTOs;

public class ProductImageDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = null!;
    public int? SortOrder { get; set; }
}
