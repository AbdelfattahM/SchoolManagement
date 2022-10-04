using School.SharedKernel;

namespace School.Domain.Entities;

public class Country : BaseEntity<int>
{
    public string Name { get; set; }

    public ICollection<Student> Students { get; set; }
}
