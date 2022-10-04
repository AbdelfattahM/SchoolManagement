namespace School.Application.Dto;

public class StudentDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ImageUrl { get; set; }

    public List<StudentCourse> Courses { get; set; }
}
