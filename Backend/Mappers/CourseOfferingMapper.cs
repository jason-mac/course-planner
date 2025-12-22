using Backend.Dtos.CourseOfferingMeeting;
using Backend.Dtos.CourseOffering;
using Backend.Models;

namespace Backend.Mappers;

public static class CourseOfferingMapper
{
    public static CourseOfferingDto ToCourseOfferingDto(this CourseOffering offering)
    {
        return new CourseOfferingDto
        {
        };
    }

    public static CourseOfferingDto ToCourseModel(this CreateCourseOfferingDto dto)
    {
        return new CourseOfferingDto
        {
        };
    }

    public static void ApplyUpdate(this CourseOffering offering, UpdateCourseOfferingDto dto)
    {
    }
}
