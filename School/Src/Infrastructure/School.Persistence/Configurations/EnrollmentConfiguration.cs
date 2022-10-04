using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Persistence.Configurations;

public class EnrollmentConfiguration : IEntityTypeConfiguration<Enrollment>
{
    public void Configure(EntityTypeBuilder<Enrollment> builder)
    {
        builder.ToTable("enrollment");
        builder.HasOne(d => d.Course)
          .WithMany(c => c.Enrollments)
          .HasForeignKey(s => s.CourseId)
          .OnDelete(DeleteBehavior.Cascade)
          .HasConstraintName("FK_Enrollments_Courses");

        builder.HasOne(d => d.Student)
          .WithMany(c => c.Enrollments)
          .HasForeignKey(s => s.StudentId)
          .OnDelete(DeleteBehavior.Cascade)
          .HasConstraintName("FK_Enrollments_Students");
    }
}
