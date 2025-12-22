using Backend.Interfaces;
using Backend.Models;
using Backend.Data;

namespace Backend.Repository;

public class CourseOfferingRepository : ICourseOfferingRepository
{
    private readonly ApplicationDbContext _db;

    public CourseOfferingRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public Task<List<CourseOffering>> GetByCourseIdAsync(int courseId)
    {
        throw new NotImplementedException();
    }

    public Task<CourseOffering?> GetByIdAsync(int offeringId)
    {
        throw new NotImplementedException();
    }

    public Task<CourseOffering?> CreateAsync(int courseId, CourseOffering offering)
    {
        throw new NotImplementedException();
    }

    public Task<CourseOffering?> UpdateAsync(int offeringId, CourseOffering offering)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int offeringId)
    {
        throw new NotImplementedException();
    }

    public Task<List<CourseOfferingMeeting>> GetMeetingsAsync(int offeringId)
    {
        throw new NotImplementedException();
    }

    public Task<CourseOfferingMeeting?> AddMeetingAsync(int offeringId, CourseOfferingMeeting meeting)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RemoveMeetingAsync(int offeringId, int meetingId)
    {
        throw new NotImplementedException();
    }
}
