using Backend.Dtos.Course;
using Backend.Models;

namespace Backend.Mappers;

public static class CourseMappers
{

    public static CourseDto ToCourseDto(this Course course)
    {
        return new CourseDto
        {
            CourseId = course.CourseId,
            Department = course.Department,
            Number = course.Number,
            Title = course.Title,
            Description = course.Description,
            Credits = course.Credits
        };
    }
}
