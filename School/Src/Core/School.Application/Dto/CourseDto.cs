namespace School.Application.Dto;

public class CourseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<CountryStudent> Students { set; get; }
}
