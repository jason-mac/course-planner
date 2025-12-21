using Microsoft.AspNetCore.Mvc;
using Backend.Data;

namespace Backend.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public CoursesController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> GetCourses()
    {
        var courses = await _db.Courses
            .Include(c => c.Prerequisites)
            .ToListAsync();

        var dtoList = courses.Select(c => new CourseReadDto
        {
            CourseId = c.CourseId,
            Code = c.Code,
            Title = c.Title,
            Description = c.Description,
            Credits = c.Credits,
            PrerequisiteIds = c.Prerequisites.Select(p => p.PrerequisiteId).ToList()
        }).ToList();

        return Ok(dtoList);
    }
}
