using Backend.Dtos.CourseOfferingMeeting;

namespace Backend.Dtos.CourseOffering;
public class CreateCourseOfferingDto
{
    public string Term { get; set; } = string.Empty;

    public string Section { get; set; } = string.Empty;

    public List<CreateCourseOfferingMeetingDto> Meetings { get; set; } = new();
}
