using School.SharedKernel;

namespace School.Domain.Entities;

public class Course : BaseEntity<int>
{
    public string Name { get; set; }
    public List<Enrollment> Enrollments { get; set; }
}
