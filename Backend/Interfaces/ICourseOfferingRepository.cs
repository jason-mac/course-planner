using Backend.Models;

namespace Backend.Interfaces;

public interface ICourseOfferingRepository
{
    Task<List<CourseOffering>> GetByCourseIdAsync(int courseId);
    Task<CourseOffering?> GetByIdAsync(int offeringId);
    Task<CourseOffering?> CreateAsync(int courseId, CourseOffering offering);
    Task<CourseOffering?> UpdateAsync(int offeringId, CourseOffering offering);
    Task<bool> DeleteAsync(int offeringId);
    Task<List<CourseOfferingMeeting>> GetMeetingsAsync(int offeringId);
    Task<CourseOfferingMeeting?> AddMeetingAsync(int offeringId, CourseOfferingMeeting meeting);
    Task<bool> RemoveMeetingAsync(int offeringId, int meetingId);
}
