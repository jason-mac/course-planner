using Backend.Dtos.Course;
using Backend.Models;

namespace Backend.Mappers;

public static class CourseMapper
{
    public static CourseDto ToCourseDto(this Course course)
    {
        return new CourseDto
        {
            CourseId = course.CourseId,
            SubjectCode = course.SubjectCode,
            CourseNumber = course.CourseNumber,
            Title = course.Title,
            Description = course.Description,
            Credits = course.Credits
        };
    }

    public static Course ToCourseModel(this CreateCourseDto dto)
    {
        return new Course
        {
            SubjectCode = dto.SubjectCode,
            CourseNumber = dto.CourseNumber,
            Title = dto.Title,
            Description = dto.Description,
            Credits = dto.Credits
        };
    }

    public static void ApplyUpdate(this Course course, UpdateCourseDto dto)
    {
        course.SubjectCode = dto.SubjectCode;
        course.CourseNumber = dto.CourseNumber;
        course.Title = dto.Title;
        course.Description = dto.Description;
        course.Credits = dto.Credits;
    }
}
