using Backend.Interfaces;
using Backend.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Backend.Dtos.CourseOffering;
using Backend.Dtos.CourseOfferingMeeting;
using Backend.Mappers;

namespace Backend.Repository;

public class CourseOfferingRepository : ICourseOfferingRepository
{
    private readonly ApplicationDbContext _db;

    public CourseOfferingRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<List<CourseOffering>> GetAllAsync(int courseId)
    {
        return await _db.CourseOfferings
          .Where(o => o.CourseId == courseId)
          .Include(o => o.Meetings)
          .ToListAsync();
    }

    public async Task<CourseOffering?> GetByIdAsync(int courseId, int offeringId)
    {
        return await _db.CourseOfferings
          .Include(o => o.Meetings)
          .FirstOrDefaultAsync(o =>
              o.CourseId == courseId &&
              o.OfferingId == offeringId);
    }

    public async Task<CourseOffering?> CreateAsync(
     int courseId,
     CreateCourseOfferingDto dto)
    {
        bool courseExists = await _db.Courses.AnyAsync(c => c.CourseId == courseId);
        if (!courseExists)
            return null;

        var offering = new CourseOffering
        {
            CourseId = courseId,
            Term = dto.Term,
            Section = dto.Section
        };

        _db.CourseOfferings.Add(offering);
        await _db.SaveChangesAsync();

        foreach (var m in dto.Meetings)
        {
            _db.CourseOfferingMeetings.Add(new CourseOfferingMeeting
            {
                OfferingId = offering.OfferingId,
                Day = m.Day,
                StartTime = m.StartTime,
                EndTime = m.EndTime,
                Location = m.Location,
                Type = m.Type
            });
        }

        await _db.SaveChangesAsync();

        await _db.Entry(offering)
            .Collection(o => o.Meetings)
            .LoadAsync();

        return offering;
    }

    public async Task<CourseOffering?> UpdateAsync(
     int offeringId,
     UpdateCourseOfferingDto dto)
    {
        var offering = await _db.CourseOfferings
            .Include(o => o.Meetings)
            .FirstOrDefaultAsync(o => o.OfferingId == offeringId);

        if (offering == null)
            return null;
        offering.ApplyUpdate(dto);
        await _db.SaveChangesAsync();
        return offering;
    }

    public async Task<bool> DeleteAsync(int offeringId)
    {
        var offering = await _db.CourseOfferings.FindAsync(offeringId);
        if (offering == null)
            return false;

        _db.CourseOfferings.Remove(offering);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<List<CourseOfferingMeeting>> GetMeetingsAsync(int offeringId)
    {
        return await _db.CourseOfferingMeetings
            .Where(m => m.OfferingId == offeringId)
            .ToListAsync();
    }

    public async Task<CourseOfferingMeeting?> AddMeetingAsync(
        int offeringId,
        CreateCourseOfferingMeetingDto dto)
    {
        var offeringExists = await _db.CourseOfferings
            .AnyAsync(o => o.OfferingId == offeringId);

        if (!offeringExists)
            return null;

        var meeting = dto.ToCourseOfferingMeeting();
        meeting.OfferingId = offeringId;

        _db.CourseOfferingMeetings.Add(meeting);
        await _db.SaveChangesAsync();

        return meeting;
    }

    public async Task<bool> RemoveMeetingAsync(
        int offeringId,
        int meetingId)
    {
        var meeting = await _db.CourseOfferingMeetings
            .FirstOrDefaultAsync(m =>
                m.OfferingId == offeringId &&
                m.MeetingId == meetingId);

        if (meeting == null)
            return false;

        _db.CourseOfferingMeetings.Remove(meeting);
        await _db.SaveChangesAsync();
        return true;
    }
}
