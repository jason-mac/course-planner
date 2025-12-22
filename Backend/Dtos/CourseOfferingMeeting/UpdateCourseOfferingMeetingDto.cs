using Backend.Enums;

namespace Backend.Dtos.CourseOfferingMeeting;
public class UpdateCourseOfferingMeetingDto
{

    public Day Day { get; set; }

    public TimeSpan? StartTime { get; set; }

    public TimeSpan? EndTime { get; set; }

    public string? Location { get; set; }

    public MeetingType Type { get; set; }
}
