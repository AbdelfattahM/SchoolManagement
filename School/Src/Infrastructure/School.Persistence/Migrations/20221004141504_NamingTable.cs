using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace School.Persistence.Migrations
{
    public partial class NamingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Students",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Courses",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Students",
                newName: "student");

            migrationBuilder.RenameTable(
                name: "Enrollments",
                newName: "enrollment");

            migrationBuilder.RenameTable(
                name: "Courses",
                newName: "course");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "country");

            migrationBuilder.RenameIndex(
                name: "IX_Students_CountryId",
                table: "student",
                newName: "IX_student_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_StudentId",
                table: "enrollment",
                newName: "IX_enrollment_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_Enrollments_CourseId",
                table: "enrollment",
                newName: "IX_enrollment_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_student",
                table: "student",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_enrollment",
                table: "enrollment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_course",
                table: "course",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_country",
                table: "country",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_student",
                table: "student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_enrollment",
                table: "enrollment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_course",
                table: "course");

            migrationBuilder.DropPrimaryKey(
                name: "PK_country",
                table: "country");

            migrationBuilder.RenameTable(
                name: "student",
                newName: "Students");

            migrationBuilder.RenameTable(
                name: "enrollment",
                newName: "Enrollments");

            migrationBuilder.RenameTable(
                name: "course",
                newName: "Courses");

            migrationBuilder.RenameTable(
                name: "country",
                newName: "Countries");

            migrationBuilder.RenameIndex(
                name: "IX_student_CountryId",
                table: "Students",
                newName: "IX_Students_CountryId");

            migrationBuilder.RenameIndex(
                name: "IX_enrollment_StudentId",
                table: "Enrollments",
                newName: "IX_Enrollments_StudentId");

            migrationBuilder.RenameIndex(
                name: "IX_enrollment_CourseId",
                table: "Enrollments",
                newName: "IX_Enrollments_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Students",
                table: "Students",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enrollments",
                table: "Enrollments",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Courses",
                table: "Courses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "Id");
        }
    }
}
