using Microsoft.AspNetCore.Mvc;
using Backend.Interfaces;
using Backend.Mappers;
using Backend.Dtos.Course;
using Backend.Queries;

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
    public async Task<IActionResult> GetAll([FromQuery] CourseQuery query)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var courses = await _courseRepo.GetAllAsync(query);
        return Ok(courses.Select(c => c.ToCourseDto()));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var course = await _courseRepo.GetByIdAsync(id);
        return course == null ? NotFound() : Ok(course.ToCourseDto());
    }

    [HttpGet("{id:int}/prerequisites")]
    public async Task<IActionResult> GetPrequisites(int id)
    {
        var prereqs = await _courseRepo.GetPrerequisitesAsync(id);
        return prereqs == null ? NotFound() : Ok(prereqs);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCourseDto dto)
    {
        var course = await _courseRepo.CreateAsync(dto);
        if (course == null)
        {
            return BadRequest("Failed to create course");
        }
        return CreatedAtAction(nameof(GetById), new { id = course.CourseId }, course.ToCourseDto());
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateCourseDto dto)
    {
        var course = await _courseRepo.UpdateAsync(id, dto);
        return course == null ? NotFound() : Ok(course.ToCourseDto());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _courseRepo.DeleteAsync(id);
        return deleted ? NoContent() : NotFound();
    }

    [HttpPost("{courseId}/prerequisites/{prereqId}")]
    public async Task<IActionResult> AddPrerequisite([FromRoute] int courseId, [FromRoute] int prereqId)
    {
        var added = await _courseRepo.AddPrerequisiteAsync(courseId, prereqId);

        if (!added)
            return BadRequest();
        return NoContent();
    }

    [HttpDelete("{courseId}/prerequisites/{prereqId}")]
    public async Task<IActionResult> RemovePrerequisite([FromRoute] int courseId, [FromRoute] int prereqId)
    {
        var removed = await _courseRepo.RemovePrerequisiteAsync(courseId, prereqId);
        if (!removed)
            return BadRequest();
        return NoContent();
    }
}
