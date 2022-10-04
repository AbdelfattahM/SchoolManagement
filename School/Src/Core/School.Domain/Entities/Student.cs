using School.SharedKernel;

namespace School.Domain.Entities;

public class Student : BaseEntity<int>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int CountryId { get; set; }
    public Country Country { get; set; }
    public List<Enrollment> Enrollments { get; set; }
}
