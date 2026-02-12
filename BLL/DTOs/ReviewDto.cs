using System;

namespace BLL.DTOs;

public class ReviewDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Comment { get; set; }
    public int Rating { get; set; }
    public string UserName { get; set; } = null!;
    public DateTimeOffset CreatedAt { get; set; }
}
