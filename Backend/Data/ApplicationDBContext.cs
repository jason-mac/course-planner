using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Course> Courses { get; set; } = null!;
    public DbSet<CoursePrerequisite> CoursePrerequisites { get; set; } = null!;
    public DbSet<CourseOffering> CourseOfferings { get; set; } = null!;
    public DbSet<CourseOfferingMeeting> CourseOfferingMeetings { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoursePrerequisite>()
            .HasKey(cp => new { cp.CourseId, cp.PrerequisiteId });

        modelBuilder.Entity<CourseOfferingMeeting>()
            .HasOne(m => m.Offering)
            .WithMany(o => o.Meetings)
            .HasForeignKey(m => m.OfferingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
