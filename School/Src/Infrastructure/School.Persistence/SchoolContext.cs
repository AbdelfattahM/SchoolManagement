using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using System.Diagnostics.Metrics;

namespace School.Persistence;

public class SchoolContext : DbContext
{
    public SchoolContext(DbContextOptions<SchoolContext> options): base(options)
    {
    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Enrollment> Enrollments { get; set; }
    public DbSet<Student> Students { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolContext).Assembly);
        SeedData(modelBuilder);


        //modelBuilder.Entity<Counter>().ToView("").HasKey

    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().HasData(new Country { Id = 1, Name = "Egypt" });
        modelBuilder.Entity<Country>().HasData(new Country { Id = 2, Name = "Omman" });
        modelBuilder.Entity<Country>().HasData(new Country { Id = 3, Name = "Saudi Arabia" });
        modelBuilder.Entity<Country>().HasData(new Country { Id = 4, Name = "Libya" });

        modelBuilder.Entity<Course>().HasData(new Course { Id = 1, Name = "Calculas" });
        modelBuilder.Entity<Course>().HasData(new Course { Id = 2, Name = "Linear Algebra" });
        modelBuilder.Entity<Course>().HasData(new Course { Id = 3, Name = "Algorithms" });

        // No enrollments
        modelBuilder.Entity<Course>().HasData(new Course { Id = 4, Name = "Quantam Mechanics" });

        modelBuilder.Entity<Student>().HasData(new Student { Id = 1, Name = "Ahmed Ali", DateOfBirth = new DateTime(2002, 09, 18), ImageUrl = "", CountryId = 1 });
        modelBuilder.Entity<Student>().HasData(new Student { Id = 2, Name = "Hend Salem", DateOfBirth = new DateTime(2000, 02, 13), ImageUrl = "", CountryId = 1 });
        modelBuilder.Entity<Student>().HasData(new Student { Id = 3, Name = "Eyad Mohammed", DateOfBirth = new DateTime(1994, 03, 20), ImageUrl = "", CountryId = 2 });

        // No enrollments
        modelBuilder.Entity<Student>().HasData(new Student { Id = 4, Name = "Lena Mustafa", DateOfBirth = new DateTime(1990, 03, 20), ImageUrl = "", CountryId = 3 });

        modelBuilder.Entity<Enrollment>().HasData(new Enrollment { Id = 1, CourseId = 1, StudentId = 1 });
        modelBuilder.Entity<Enrollment>().HasData(new Enrollment { Id = 2, CourseId = 2, StudentId = 1 });
        modelBuilder.Entity<Enrollment>().HasData(new Enrollment { Id = 3, CourseId = 3, StudentId = 1 });
        modelBuilder.Entity<Enrollment>().HasData(new Enrollment { Id = 4, CourseId = 1, StudentId = 2 });
        modelBuilder.Entity<Enrollment>().HasData(new Enrollment { Id = 5, CourseId = 3, StudentId = 2 });
        modelBuilder.Entity<Enrollment>().HasData(new Enrollment { Id = 6, CourseId = 2, StudentId = 3 });
        modelBuilder.Entity<Enrollment>().HasData(new Enrollment { Id = 7, CourseId = 3, StudentId = 3 });
        //modelBuilder.Entity<EnrollmentDto>().HasData(new EnrollmentDto { });
    }
}
