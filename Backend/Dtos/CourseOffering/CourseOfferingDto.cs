using Backend.Dtos.CourseOfferingMeeting;

namespace Backend.Dtos.CourseOffering;
public class CourseOfferingDto
{
    public int OfferingId { get; set; }

    public int CourseId { get; set; }

    public string Term { get; set; } = string.Empty;

    public string Section { get; set; } = string.Empty;

    public List<CourseOfferingMeetingDto> Meetings { get; set; } = new();
}
