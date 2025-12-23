using Backend.Models;
using Backend.Dtos.CourseOffering;
using Backend.Dtos.CourseOfferingMeeting;

namespace Backend.Interfaces;

public interface ICourseOfferingRepository
{
    Task<List<CourseOffering>> GetAllAsync(int courseId);
    Task<CourseOffering?> GetByIdAsync(int courseId, int offeringId);
    Task<CourseOffering?> CreateAsync(int courseId, CreateCourseOfferingDto dto);
    Task<CourseOffering?> UpdateAsync(int offeringId, UpdateCourseOfferingDto dto);
    Task<bool> DeleteAsync(int offeringId);
    Task<List<CourseOfferingMeeting>> GetMeetingsAsync(int offeringId);
    Task<CourseOfferingMeeting?> AddMeetingAsync(
        int offeringId,
        CreateCourseOfferingMeetingDto dto
    );
    Task<bool> RemoveMeetingAsync(int offeringId, int meetingId);
}
