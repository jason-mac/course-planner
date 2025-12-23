using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SubjectCode = table.Column<string>(type: "text", nullable: false),
                    CourseNumber = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Credits = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "CourseOfferings",
                columns: table => new
                {
                    OfferingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    Term = table.Column<string>(type: "text", nullable: false),
                    Section = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOfferings", x => x.OfferingId);
                    table.ForeignKey(
                        name: "FK_CourseOfferings_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursePrerequisites",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "integer", nullable: false),
                    PrerequisiteId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursePrerequisites", x => new { x.CourseId, x.PrerequisiteId });
                    table.ForeignKey(
                        name: "FK_CoursePrerequisites_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursePrerequisites_Courses_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseOfferingMeetings",
                columns: table => new
                {
                    MeetingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Day = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    EndTime = table.Column<TimeSpan>(type: "interval", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    OfferingId = table.Column<int>(type: "integer", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseOfferingMeetings", x => x.MeetingId);
                    table.ForeignKey(
                        name: "FK_CourseOfferingMeetings_CourseOfferings_OfferingId",
                        column: x => x.OfferingId,
                        principalTable: "CourseOfferings",
                        principalColumn: "OfferingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseNumber", "Credits", "Description", "SubjectCode", "Title" },
                values: new object[,]
                {
                    { 1, 110, 4, "Introduction to systematic program design using a functional programming language. Focuses on problem solving, abstraction, and data-driven design.", "CPSC", "Computation, Programs, and Programming" },
                    { 2, 121, 4, "Introduction to formal models of computation, including logic, proofs, and abstract machines. Emphasizes reasoning about program correctness.", "CPSC", "Models of Computation" },
                    { 3, 210, 4, "Design and construction of large software systems with emphasis on modularity, abstraction, testing, and documentation.", "CPSC", "Software Construction" },
                    { 4, 213, 4, "Introduction to computer organization, operating systems concepts, memory hierarchy, and low-level programming.", "CPSC", "Computer Systems" },
                    { 5, 221, 4, "Design and analysis of fundamental data structures and algorithms including lists, trees, graphs, and algorithmic complexity.", "CPSC", "Basic Algorithms and Data Structures" },
                    { 6, 211, 4, "Introduction to digital logic, computer organization, and low-level programming with emphasis on hardware–software interaction.", "CPEN", "Computing Systems I" },
                    { 7, 212, 4, "Continuation of CPEN 211 covering advanced computer architecture, pipelines, memory systems, and parallelism.", "CPEN", "Computing Systems II" },
                    { 8, 221, 3, "Matrices, systems of linear equations, determinants, vector spaces, eigenvalues, and applications to engineering problems.", "MATH", "Matrix Algebra" },
                    { 9, 220, 3, "Introduction to mathematical reasoning and proof techniques including induction, contradiction, and formal logic.", "MATH", "Mathematical Proof" },
                    { 10, 251, 3, "Basic statistical methods including probability, random variables, estimation, hypothesis testing, and data analysis.", "STAT", "Elementary Statistics" }
                });

            migrationBuilder.InsertData(
                table: "CourseOfferings",
                columns: new[] { "OfferingId", "CourseId", "Section", "Term" },
                values: new object[,]
                {
                    { 1, 1, "001", "2024W" },
                    { 2, 1, "002", "2024W" },
                    { 3, 3, "101", "2024W" },
                    { 4, 3, "201", "2025S" },
                    { 5, 5, "001", "2024W" },
                    { 6, 6, "001", "2024W" },
                    { 7, 7, "001", "2025S" }
                });

            migrationBuilder.InsertData(
                table: "CoursePrerequisites",
                columns: new[] { "CourseId", "PrerequisiteId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 3 },
                    { 5, 2 },
                    { 5, 3 },
                    { 6, 1 },
                    { 7, 6 }
                });

            migrationBuilder.InsertData(
                table: "CourseOfferingMeetings",
                columns: new[] { "MeetingId", "Day", "EndTime", "Location", "OfferingId", "StartTime", "Type" },
                values: new object[,]
                {
                    { 1, 0, new TimeSpan(0, 10, 30, 0, 0), "DMP 201", 1, new TimeSpan(0, 9, 0, 0, 0), 0 },
                    { 2, 2, new TimeSpan(0, 10, 30, 0, 0), "DMP 201", 1, new TimeSpan(0, 9, 0, 0, 0), 0 },
                    { 3, 1, new TimeSpan(0, 12, 30, 0, 0), "ANGU 098", 2, new TimeSpan(0, 11, 0, 0, 0), 0 },
                    { 4, 0, new TimeSpan(0, 15, 30, 0, 0), "ICCS 236", 3, new TimeSpan(0, 14, 0, 0, 0), 0 },
                    { 5, 3, new TimeSpan(0, 15, 30, 0, 0), "ICCS 236", 3, new TimeSpan(0, 14, 0, 0, 0), 0 },
                    { 6, 4, new TimeSpan(0, 11, 30, 0, 0), "EOS 120", 5, new TimeSpan(0, 10, 0, 0, 0), 0 },
                    { 7, 1, new TimeSpan(0, 15, 0, 0, 0), "KAIS 1010", 6, new TimeSpan(0, 13, 0, 0, 0), 2 },
                    { 8, 0, new TimeSpan(0, 9, 30, 0, 0), "CHBE 102", 7, new TimeSpan(0, 8, 0, 0, 0), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferingMeetings_OfferingId",
                table: "CourseOfferingMeetings",
                column: "OfferingId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseOfferings_CourseId",
                table: "CourseOfferings",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursePrerequisites_PrerequisiteId",
                table: "CoursePrerequisites",
                column: "PrerequisiteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CourseOfferingMeetings");

            migrationBuilder.DropTable(
                name: "CoursePrerequisites");

            migrationBuilder.DropTable(
                name: "CourseOfferings");

            migrationBuilder.DropTable(
                name: "Courses");
        }
    }
}
