using Backend.Interfaces;
using Backend.Models;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Backend.Dtos.Course;
using Backend.Mappers;
using Backend.Queries;


namespace Backend.Repository;

public class CourseRepository : ICourseRepository
{
    private readonly ApplicationDbContext _db;

    public CourseRepository(ApplicationDbContext db)
    {
        this._db = db;

    }

    public async Task<List<Course>> GetAllAsync(CourseQuery query)
    {
        var courses = _db.Courses.AsQueryable();

        if (!string.IsNullOrWhiteSpace(query.SubjectCode))
            courses = courses.Where(c => c.SubjectCode.Contains(query.SubjectCode));

        if (query.CourseNumber.HasValue)
            courses = courses.Where(c => c.CourseNumber == query.CourseNumber.Value);

        if (query.MinYear.HasValue)
            courses = courses.Where(c => c.CourseNumber / 100 >= query.MinYear.Value);

        if (query.MaxYear.HasValue)
            courses = courses.Where(c => c.CourseNumber / 100 <= query.MaxYear.Value);

        if (!string.IsNullOrWhiteSpace(query.Title))
            courses = courses.Where(c => c.Title == query.Title);

        if (query.Credits.HasValue)
            courses = courses.Where(c => c.Credits == query.Credits.Value);

        return await courses.ToListAsync();
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _db.Courses.FindAsync(id);
    }

    public async Task<List<Course?>?> GetPrerequisitesAsync(int id)
    {
        var exists = await _db.Courses.AnyAsync(c => c.CourseId == id);
        if (!exists)
            return null;
        var prerequisites = await _db.CoursePrerequisites
          .Where(cp => cp.CourseId == id)
          .Select(cp => cp.Prerequisite)
          .ToListAsync();
        return prerequisites;
    }

    public async Task<Course?> CreateAsync(CreateCourseDto dto)
    {
        var course = dto.ToCourseModel();
        _db.Courses.Add(course);
        await _db.SaveChangesAsync();
        return course;
    }

    public async Task<Course?> UpdateAsync(int id, UpdateCourseDto dto)
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

    public async Task<bool> DeleteAsync(int id)
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
