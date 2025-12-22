using Microsoft.AspNetCore.Mvc;
using Backend.Data;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.Dtos.Course;

namespace Backend.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    private readonly ICourseRepository _courseRepo;

    public CoursesController(ApplicationDbContext db, ICourseRepository courseRepo)
    {
        this._db = db;
        this._courseRepo = courseRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _courseRepo.GetAllAsync();
        return courses == null ? NotFound() : Ok(courses.Select(c => c.ToCourseDto()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var course = await _courseRepo.GetByIdAsync(id);
        return course == null ? NotFound() : Ok(course.ToCourseDto());
    }

    [HttpGet]
    public async Task<IActionResult> Create([FromRoute] CreateCourseDto dto)
    {
        var course = await _courseRepo.Create(dto);
        return Ok(course);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCourseDto dto)
    {
        var course = await _courseRepo.Update(id, dto);
        return course == null ? NotFound() : Ok(course.ToCourseDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        var deleted = await _courseRepo.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}
