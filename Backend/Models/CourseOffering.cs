using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;
public class CourseOffering
{
    [Key]
    public int OfferingId { get; set; }

    [Required]
    public int CourseId { get; set; }

    [ForeignKey(nameof(CourseId))]
    public Course Course { get; set; } = null!;

    [Required]
    public string Term { get; set; } = string.Empty;

    [Required]
    public string Section { get; set; } = string.Empty;

    public List<CourseOfferingMeeting> Meetings { get; set; } = new();
}
