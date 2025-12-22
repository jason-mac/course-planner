namespace Backend.Dtos.Course;

public class CreateCourseDto
{
    public string SubjectCode { get; set; } = string.Empty;

    public int CourseNumber { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int Credits { get; set; }

}
