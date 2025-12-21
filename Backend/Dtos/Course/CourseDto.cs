namespace Backend.Dtos.Course;

public class CourseDto
{
    public int CourseId { get; set; }

    public string Department { get; set; } = string.Empty;

    public int Number { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public int Credits { get; set; }
}
