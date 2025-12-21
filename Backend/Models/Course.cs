using System.ComponentModel.DataAnnotations;
namespace Backend.Models;
public class Course
{
    [Key]
    public int CourseId { get; set; }

    [Required]
    public string Code { get; set; } = string.Empty;

    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    public int Credits { get; set; }
}
