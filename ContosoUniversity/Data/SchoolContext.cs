using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
            
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { ID = 1, Name = "Carson Alexander", EnrollmentDate = DateTime.Parse("2019-09-01") },
                new Student { ID = 2, Name = "Meredith Alonso", EnrollmentDate = DateTime.Parse("2017-09-01") },
                new Student { ID = 3, Name = "Arturo Anand", EnrollmentDate = DateTime.Parse("2018-09-01") },
                new Student { ID = 4, Name = "Gytis Barzdukas", EnrollmentDate = DateTime.Parse("2017-09-01") },
                new Student { ID = 5, Name = "Yan Li", EnrollmentDate = DateTime.Parse("2017-09-01") },
                new Student { ID = 6, Name = "Peggy Justice", EnrollmentDate = DateTime.Parse("2016-09-01") },
                new Student { ID = 7, Name = "Laura Norman", EnrollmentDate = DateTime.Parse("2018-09-01") },
                new Student { ID = 8, Name = "Nino Olivetto", EnrollmentDate = DateTime.Parse("2019-09-01") }
            );
            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, Title = "Chemistry", Credits = 3 },
                new Course { CourseId = 2, Title = "Microeconomics", Credits = 3 },
                new Course { CourseId = 3, Title = "Macroeconomics", Credits = 3 },
                new Course { CourseId = 4, Title = "Calculus", Credits = 4 },
                new Course { CourseId = 5, Title = "Trigonometry", Credits = 4 },
                new Course { CourseId = 6, Title = "Composition", Credits = 3 },
                new Course { CourseId = 7, Title = "Literature", Credits = 4 }
            );

            modelBuilder.Entity<Enrollment>().HasData(
                new Enrollment { EnrollmentID = 1, StudentID = 1, CourseId = 1, Grade = Grade.A },
                new Enrollment { EnrollmentID = 2, StudentID = 1, CourseId = 2, Grade = Grade.C },
                new Enrollment { EnrollmentID = 3, StudentID = 1, CourseId = 3, Grade = Grade.B },
                new Enrollment { EnrollmentID = 4, StudentID = 2, CourseId = 4, Grade = Grade.B },
                new Enrollment { EnrollmentID = 5, StudentID = 2, CourseId = 5, Grade = Grade.E },
                new Enrollment { EnrollmentID = 6, StudentID = 2, CourseId = 6, Grade = Grade.E },
                new Enrollment { EnrollmentID = 7, StudentID = 3, CourseId = 1 },
                new Enrollment { EnrollmentID = 8, StudentID = 4, CourseId = 1 },
                new Enrollment { EnrollmentID = 9, StudentID = 4, CourseId = 2, Grade = Grade.E },
                new Enrollment { EnrollmentID = 10, StudentID = 5, CourseId = 3, Grade = Grade.C },
                new Enrollment { EnrollmentID = 11, StudentID = 6, CourseId = 4 },
                new Enrollment { EnrollmentID = 12, StudentID = 7, CourseId = 5, Grade = Grade.A }
            );
        }

    }
}
