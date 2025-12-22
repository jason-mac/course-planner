using Backend.Dtos.CourseOfferingMeeting;
using Backend.Models;

namespace Backend.Mappers;

public static class CourseOfferingMeetingMapper
{
    public static CourseOfferingMeetingDto ToCourseOfferingMeetingDto(this CourseOfferingMeeting meeting)
    {
        return new CourseOfferingMeetingDto
        {
        };
    }

    public static CourseOfferingMeetingDto ToCourseModel(this CreateCourseOfferingMeetingDto dto)
    {
        return new CourseOfferingMeetingDto
        {
        };
    }

    public static void ApplyUpdate(this CourseOfferingMeeting meeting, UpdateCourseOfferingMeetingDto dto)
    {
    }
}
