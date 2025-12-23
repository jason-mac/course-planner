using Backend.Models;
using Backend.Dtos.Course;
using Backend.Queries;

namespace Backend.Interfaces;

public interface ICourseRepository
{
    Task<List<Course>> GetAllAsync(CourseQuery query);
    Task<Course?> GetByIdAsync(int id);
    Task<List<Course?>?> GetPrerequisitesAsync(int courseId);
    Task<Course?> CreateAsync(CreateCourseDto dto);
    Task<Course?> UpdateAsync(int id, UpdateCourseDto dto);
    Task<bool> DeleteAsync(int id);
    Task<bool> AddPrerequisiteAsync(int courseId, int prereqId);
    Task<bool> RemovePrerequisiteAsync(int courseId, int prereqId);
}
