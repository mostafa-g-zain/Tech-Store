using System.Collections.Generic;

namespace BLL.DTOs;

public class CategoryDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Slug { get; set; }
    public string? Icon { get; set; }
    public List<CategoryDto> SubCategories { get; set; } = new();
}
