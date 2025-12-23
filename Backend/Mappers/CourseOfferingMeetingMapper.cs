using Backend.Dtos.CourseOfferingMeeting;
using Backend.Models;

namespace Backend.Mappers;

public static class CourseOfferingMeetingMapper
{
    public static CourseOfferingMeetingDto ToCourseOfferingMeetingDto(this CourseOfferingMeeting meeting)
    {
        return new CourseOfferingMeetingDto
        {
            MeetingId = meeting.MeetingId,
            Day = meeting.Day,
            StartTime = meeting.StartTime,
            EndTime = meeting.EndTime,
            Location = meeting.Location,
            Type = meeting.Type
        };
    }

    public static CourseOfferingMeeting ToCourseOfferingMeeting(this CreateCourseOfferingMeetingDto dto)
    {
        return new CourseOfferingMeeting
        {
            Day = dto.Day,
            StartTime = dto.StartTime,
            EndTime = dto.EndTime,
            Location = dto.Location,
            Type = dto.Type
        };
    }

    public static void ApplyUpdate(
        this CourseOfferingMeeting meeting,
        UpdateCourseOfferingMeetingDto dto)
    {
        meeting.Day = dto.Day;
        meeting.StartTime = dto.StartTime;
        meeting.EndTime = dto.EndTime;
        meeting.Location = dto.Location;
        meeting.Type = dto.Type;
    }
}
