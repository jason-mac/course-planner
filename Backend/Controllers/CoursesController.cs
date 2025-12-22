using Microsoft.AspNetCore.Mvc;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.Dtos.Course;

namespace Backend.Controllers;

[ApiController]
[Route("api/courses")]
public class CoursesController : ControllerBase
{
    private readonly ICourseRepository _courseRepo;

    public CoursesController(ICourseRepository courseRepo)
    {
        _courseRepo = courseRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCourses()
    {
        var courses = await _courseRepo.GetAllAsync();
        return Ok(courses.Select(c => c.ToCourseDto()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var course = await _courseRepo.GetByIdAsync(id);
        return course == null ? NotFound() : Ok(course.ToCourseDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCourseDto dto)
    {
        var course = await _courseRepo.Create(dto);
        if (course == null)
        {
            return BadRequest("Failed to create course");
        }
        return CreatedAtAction(nameof(GetById), new { id = course.CourseId }, course.ToCourseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseDto dto)
    {
        var course = await _courseRepo.Update(id, dto);
        return course == null ? NotFound() : Ok(course.ToCourseDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _courseRepo.Delete(id);
        return deleted ? NoContent() : NotFound();
    }
}
