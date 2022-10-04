using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;

namespace School.Persistence.Configurations;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("student");
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).IsRequired().HasMaxLength(255);
        builder.Property(e => e.ImageUrl).IsRequired().HasMaxLength(500);
        builder.Property(e => e.DateOfBirth).IsRequired().HasColumnType("datetime");

        // one-to-many
        builder.HasOne(d => d.Country)
           .WithMany(c => c.Students)
           .HasForeignKey(s => s.CountryId)
           .OnDelete(DeleteBehavior.Cascade)
           .HasConstraintName("FK_Students_Countries");
    }
}
