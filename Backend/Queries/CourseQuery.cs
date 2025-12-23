namespace Backend.Queries;

public class CourseQuery
{
    public string? SubjectCode { get; set; }

    public int? CourseNumber { get; set; }

    public int? MinYear { get; set; }

    public int? MaxYear { get; set; }

    public string? Title { get; set; }

    public int? Credits { get; set; }
}
