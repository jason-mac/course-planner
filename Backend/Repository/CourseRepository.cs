using Backend.Interfaces;
using Backend.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Backend.Dtos.Course;
using Backend.Mappers;
namespace Backend.Repository;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _db;

    public CourseRepository(ApplicationDbContext db)
    {
        this._db = db;

    }

    public async Task<List<Course>> GetAllAsync()
    {
        return await _db.Courses.ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _db.Courses.FindAsync(id);
    }

    public async Task<List<Course>?> GetPrerequisites(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<Course?> Create(CreateCourseDto dto)
    {
        var course = dto.ToCourseModel();
        _db.Courses.Add(course);
        await _db.SaveChangesAsync();
        return course;
    }

    public async Task<Course?> Update(int id, UpdateCourseDto dto)
    {
        var course = await _db.Courses.FindAsync(id);
        if (course == null)
        {
            return null;
        }
        course.ApplyUpdate(dto);
        await _db.SaveChangesAsync();
        return course;
    }

    public async Task<bool> Delete(int id)
    {
        var course = await _db.Courses.FindAsync(id);
        if (course == null)
        {
            return false;
        }
        _db.Courses.Remove(course);
        await _db.SaveChangesAsync();
        return true;
    }
}
