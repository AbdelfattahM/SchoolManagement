﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School.Persistence;

#nullable disable

namespace School.Persistence.Migrations
{
    [DbContext(typeof(SchoolContext))]
    partial class SchoolContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.9");

            modelBuilder.Entity("School.Domain.Entities.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("country", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Egypt"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Omman"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Saudi Arabia"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Libya"
                        });
                });

            modelBuilder.Entity("School.Domain.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("course", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Calculas"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Linear Algebra"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Algorithms"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Quantam Mechanics"
                        });
                });

            modelBuilder.Entity("School.Domain.Entities.Enrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CourseId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("StudentId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("enrollment", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CourseId = 1,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 2,
                            CourseId = 2,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 3,
                            CourseId = 3,
                            StudentId = 1
                        },
                        new
                        {
                            Id = 4,
                            CourseId = 1,
                            StudentId = 2
                        },
                        new
                        {
                            Id = 5,
                            CourseId = 3,
                            StudentId = 2
                        },
                        new
                        {
                            Id = 6,
                            CourseId = 2,
                            StudentId = 3
                        },
                        new
                        {
                            Id = 7,
                            CourseId = 3,
                            StudentId = 3
                        });
                });

            modelBuilder.Entity("School.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CountryId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("student", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            DateOfBirth = new DateTime(2002, 9, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "",
                            Name = "Ahmed Ali"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            DateOfBirth = new DateTime(2000, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "",
                            Name = "Hend Salem"
                        },
                        new
                        {
                            Id = 3,
                            CountryId = 2,
                            DateOfBirth = new DateTime(1994, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "",
                            Name = "Eyad Mohammed"
                        },
                        new
                        {
                            Id = 4,
                            CountryId = 3,
                            DateOfBirth = new DateTime(1990, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ImageUrl = "",
                            Name = "Lena Mustafa"
                        });
                });

            modelBuilder.Entity("School.Domain.Entities.Enrollment", b =>
                {
                    b.HasOne("School.Domain.Entities.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Enrollments_Courses");

                    b.HasOne("School.Domain.Entities.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Enrollments_Students");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("School.Domain.Entities.Student", b =>
                {
                    b.HasOne("School.Domain.Entities.Country", "Country")
                        .WithMany("Students")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Students_Countries");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("School.Domain.Entities.Country", b =>
                {
                    b.Navigation("Students");
                });

            modelBuilder.Entity("School.Domain.Entities.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("School.Domain.Entities.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
