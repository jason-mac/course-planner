using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;
public class CourseOfferingMeeting
{
    [Key]
    public int MeetingId { get; set; }

    [Required]
    public Day Day { get; set; }

    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }

    public string? Location { get; set; }

    [Required]
    public int OfferingId { get; set; }

    [Required]
    public MeetingType Type { get; set; }

    [ForeignKey(nameof(OfferingId))]
    public CourseOffering Offering { get; set; } = null!;
}
