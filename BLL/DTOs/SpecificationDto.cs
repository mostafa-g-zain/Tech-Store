namespace BLL.DTOs;

public class SpecificationDto
{
    public int Id { get; set; }
    public string SpecKey { get; set; } = null!;
    public string SpecValue { get; set; } = null!;
    public int? SortOrder { get; set; }
}
