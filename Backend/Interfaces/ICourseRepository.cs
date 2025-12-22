using Backend.Models;
using Backend.Dtos.Course;

namespace Backend.Interfaces;

public interface ICourseRepository
{
    Task<List<Course>> GetAllAsync();
    Task<Course?> GetByIdAsync(int id);
    Task<List<Course>?> GetPrequisites(int id);
    Task<Course?> Create(CreateCourseDto dto);
    Task<Course?> Update(int id, UpdateCourseDto dto);
    Task<bool> Delete(int id);
}


