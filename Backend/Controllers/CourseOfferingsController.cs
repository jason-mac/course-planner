using Backend.Interfaces;
using Backend.Dtos.CourseOffering;
using Backend.Dtos.CourseOfferingMeeting;
using Backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/courses/{courseId}/offerings")]
public class CourseOfferingsController : ControllerBase
{
    private readonly ICourseOfferingRepository _offeringRepo;

    public CourseOfferingsController(ICourseOfferingRepository offeringRepo)
    {
        _offeringRepo = offeringRepo;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(int courseId)
    {
        var offerings = await _offeringRepo.GetAllAsync(courseId);
        return offerings == null
            ? NotFound()
            : Ok(offerings.Select(o => o.ToCourseOfferingDto()));
    }

    [HttpGet("{offeringId:int}")]
    public async Task<IActionResult> GetById(
        [FromRoute] int courseId,
        [FromRoute] int offeringId)
    {
        var offering = await _offeringRepo.GetByIdAsync(courseId, offeringId);
        return offering == null
            ? NotFound()
            : Ok(offering.ToCourseOfferingDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        [FromRoute] int courseId,
        [FromBody] CreateCourseOfferingDto dto)
    {
        var offering = await _offeringRepo.CreateAsync(courseId, dto);
        return offering == null
            ? NotFound()
            : CreatedAtAction(
                nameof(GetById),
                new { courseId, offeringId = offering.OfferingId },
                offering.ToCourseOfferingDto()
            );
    }

    [HttpPut("{offeringId:int}")]
    public async Task<IActionResult> Update(
        [FromRoute] int courseId,
        [FromRoute] int offeringId,
        [FromBody] UpdateCourseOfferingDto dto)
    {
        var updated = await _offeringRepo.UpdateAsync(offeringId, dto);
        return updated == null ? NotFound() : NoContent();
    }

    [HttpDelete("{offeringId:int}")]
    public async Task<IActionResult> Delete(
        [FromRoute] int courseId,
        [FromRoute] int offeringId)
    {
        var deleted = await _offeringRepo.DeleteAsync(offeringId);
        return deleted ? NoContent() : NotFound();
    }

    [HttpGet("{offeringId:int}/meetings")]
    public async Task<IActionResult> GetMeetings(
        [FromRoute] int courseId,
        [FromRoute] int offeringId)
    {
        var meetings = await _offeringRepo.GetMeetingsAsync(offeringId);
        return meetings == null
            ? NotFound()
            : Ok(meetings.Select(m => m.ToCourseOfferingMeetingDto()));
    }

    [HttpPost("{offeringId:int}/meetings")]
    public async Task<IActionResult> AddMeeting(
        [FromRoute] int courseId,
        [FromRoute] int offeringId,
        [FromBody] CreateCourseOfferingMeetingDto dto)
    {
        var meeting = await _offeringRepo.AddMeetingAsync(offeringId, dto);
        return meeting == null
            ? NotFound()
            : Ok(meeting.ToCourseOfferingMeetingDto());
    }

    [HttpDelete("{offeringId:int}/meetings/{meetingId:int}")]
    public async Task<IActionResult> RemoveMeeting(
        [FromRoute] int courseId,
        [FromRoute] int offeringId,
        [FromRoute] int meetingId)
    {
        var removed = await _offeringRepo.RemoveMeetingAsync(offeringId, meetingId);
        return removed ? NoContent() : NotFound();
    }
}
