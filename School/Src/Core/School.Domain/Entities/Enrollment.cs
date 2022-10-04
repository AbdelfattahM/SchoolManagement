using School.SharedKernel;

namespace School.Domain.Entities;

public class Enrollment : BaseEntity<int>
{
    public int StudentId { set; get; }
    public int CourseId { set; get; }

    public Student Student { get; set; }
    public Course Course { get; set; }
}
