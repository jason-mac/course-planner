using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Enums;

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

        // =========================
        // COURSES
        // =========================
        modelBuilder.Entity<Course>().HasData(
     new Course
     {
         CourseId = 1,
         SubjectCode = "CPSC",
         CourseNumber = 110,
         Title = "Computation, Programs, and Programming",
         Description = "Introduction to systematic program design using a functional programming language. Focuses on problem solving, abstraction, and data-driven design.",
         Credits = 4
     },
     new Course
     {
         CourseId = 2,
         SubjectCode = "CPSC",
         CourseNumber = 121,
         Title = "Models of Computation",
         Description = "Introduction to formal models of computation, including logic, proofs, and abstract machines. Emphasizes reasoning about program correctness.",
         Credits = 4
     },
     new Course
     {
         CourseId = 3,
         SubjectCode = "CPSC",
         CourseNumber = 210,
         Title = "Software Construction",
         Description = "Design and construction of large software systems with emphasis on modularity, abstraction, testing, and documentation.",
         Credits = 4
     },
     new Course
     {
         CourseId = 4,
         SubjectCode = "CPSC",
         CourseNumber = 213,
         Title = "Computer Systems",
         Description = "Introduction to computer organization, operating systems concepts, memory hierarchy, and low-level programming.",
         Credits = 4
     },
     new Course
     {
         CourseId = 5,
         SubjectCode = "CPSC",
         CourseNumber = 221,
         Title = "Basic Algorithms and Data Structures",
         Description = "Design and analysis of fundamental data structures and algorithms including lists, trees, graphs, and algorithmic complexity.",
         Credits = 4
     },
     new Course
     {
         CourseId = 6,
         SubjectCode = "CPEN",
         CourseNumber = 211,
         Title = "Computing Systems I",
         Description = "Introduction to digital logic, computer organization, and low-level programming with emphasis on hardware–software interaction.",
         Credits = 4
     },
     new Course
     {
         CourseId = 7,
         SubjectCode = "CPEN",
         CourseNumber = 212,
         Title = "Computing Systems II",
         Description = "Continuation of CPEN 211 covering advanced computer architecture, pipelines, memory systems, and parallelism.",
         Credits = 4
     },
     new Course
     {
         CourseId = 8,
         SubjectCode = "MATH",
         CourseNumber = 221,
         Title = "Matrix Algebra",
         Description = "Matrices, systems of linear equations, determinants, vector spaces, eigenvalues, and applications to engineering problems.",
         Credits = 3
     },
     new Course
     {
         CourseId = 9,
         SubjectCode = "MATH",
         CourseNumber = 220,
         Title = "Mathematical Proof",
         Description = "Introduction to mathematical reasoning and proof techniques including induction, contradiction, and formal logic.",
         Credits = 3
     },
     new Course
     {
         CourseId = 10,
         SubjectCode = "STAT",
         CourseNumber = 251,
         Title = "Elementary Statistics",
         Description = "Basic statistical methods including probability, random variables, estimation, hypothesis testing, and data analysis.",
         Credits = 3
     }
 );

        // =========================
        // PREREQUISITES
        // =========================
        modelBuilder.Entity<CoursePrerequisite>().HasData(
            new CoursePrerequisite { CourseId = 2, PrerequisiteId = 1 },
            new CoursePrerequisite { CourseId = 3, PrerequisiteId = 1 },
            new CoursePrerequisite { CourseId = 4, PrerequisiteId = 3 },
            new CoursePrerequisite { CourseId = 5, PrerequisiteId = 2 },
            new CoursePrerequisite { CourseId = 5, PrerequisiteId = 3 },
            new CoursePrerequisite { CourseId = 6, PrerequisiteId = 1 },
            new CoursePrerequisite { CourseId = 7, PrerequisiteId = 6 }
        );

        // =========================
        // COURSE OFFERINGS
        // =========================
        modelBuilder.Entity<CourseOffering>().HasData(
            new CourseOffering { OfferingId = 1, CourseId = 1, Term = "2024W", Section = "001" },
            new CourseOffering { OfferingId = 2, CourseId = 1, Term = "2024W", Section = "002" },
            new CourseOffering { OfferingId = 3, CourseId = 3, Term = "2024W", Section = "101" },
            new CourseOffering { OfferingId = 4, CourseId = 3, Term = "2025S", Section = "201" },
            new CourseOffering { OfferingId = 5, CourseId = 5, Term = "2024W", Section = "001" },
            new CourseOffering { OfferingId = 6, CourseId = 6, Term = "2024W", Section = "001" },
            new CourseOffering { OfferingId = 7, CourseId = 7, Term = "2025S", Section = "001" }
        );

        // =========================
        // COURSE OFFERING MEETINGS
        // =========================
        modelBuilder.Entity<CourseOfferingMeeting>().HasData(
            new CourseOfferingMeeting { MeetingId = 1, OfferingId = 1, Day = Day.Monday, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 30, 0), Type = MeetingType.Lecture, Location = "DMP 201" },
            new CourseOfferingMeeting { MeetingId = 2, OfferingId = 1, Day = Day.Wednesday, StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(10, 30, 0), Type = MeetingType.Lecture, Location = "DMP 201" },

            new CourseOfferingMeeting { MeetingId = 3, OfferingId = 2, Day = Day.Tuesday, StartTime = new TimeSpan(11, 0, 0), EndTime = new TimeSpan(12, 30, 0), Type = MeetingType.Lecture, Location = "ANGU 098" },

            new CourseOfferingMeeting { MeetingId = 4, OfferingId = 3, Day = Day.Monday, StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(15, 30, 0), Type = MeetingType.Lecture, Location = "ICCS 236" },
            new CourseOfferingMeeting { MeetingId = 5, OfferingId = 3, Day = Day.Thursday, StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(15, 30, 0), Type = MeetingType.Lecture, Location = "ICCS 236" },

            new CourseOfferingMeeting { MeetingId = 6, OfferingId = 5, Day = Day.Friday, StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(11, 30, 0), Type = MeetingType.Lecture, Location = "EOS 120" },

            new CourseOfferingMeeting { MeetingId = 7, OfferingId = 6, Day = Day.Tuesday, StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(15, 0, 0), Type = MeetingType.Lab, Location = "KAIS 1010" },

            new CourseOfferingMeeting { MeetingId = 8, OfferingId = 7, Day = Day.Monday, StartTime = new TimeSpan(8, 0, 0), EndTime = new TimeSpan(9, 30, 0), Type = MeetingType.Lecture, Location = "CHBE 102" }
        );
    }
}
