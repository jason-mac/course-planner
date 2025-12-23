using Backend.Dtos.CourseOffering;
using Backend.Models;

namespace Backend.Mappers;

public static class CourseOfferingMapper
{
    public static CourseOfferingDto ToCourseOfferingDto(this CourseOffering offering)
    {

        return new CourseOfferingDto
        {
            OfferingId = offering.OfferingId,
            CourseId = offering.CourseId,
            Term = offering.Term,
            Section = offering.Section,
            Meetings = offering.Meetings.Select(m => m.ToCourseOfferingMeetingDto()).ToList()
        };
    }

    public static CourseOffering ToCourseOffering(this CreateCourseOfferingDto dto)
    {
        return new CourseOffering
        {
            Term = dto.Term,
            Section = dto.Section,
            Meetings = dto.Meetings.Select(m => m.ToCourseOfferingMeeting()).ToList()
        };
    }



    public static void ApplyUpdate(this CourseOffering offering, UpdateCourseOfferingDto dto)
    {
        offering.Term = dto.Term;
        offering.Section = dto.Section;

        offering.Meetings.Clear();

        foreach (var meetingDto in dto.Meetings)
        {
            offering.Meetings.Add(meetingDto.ToCourseOfferingMeeting());
        }
    }

}
