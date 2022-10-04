namespace School.Domain.Specifications.Courses;

public class CourseFilter : BaseFilter
{
    public int? Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
