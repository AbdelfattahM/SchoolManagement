using Ardalis.Specification;
using School.Domain.Entities;

namespace School.Domain.Specifications.Students;

public class StudentByIdSpec 
    : Specification<Student>, ISingleResultSpecification
{
    public StudentByIdSpec(StudentFilter filter)
    {
        if (!filter.IsTrackingEnabled)
        {
            Query.AsNoTracking();
        }

        if (filter.LoadChildren)
        {
            Query.Include(x => x.Enrollments);
        }

        if (filter.Id != null)
        {
            Query.Where(b => b.Id == filter.Id);
        }

        Query.OrderBy(b => b.Id);
    }
}