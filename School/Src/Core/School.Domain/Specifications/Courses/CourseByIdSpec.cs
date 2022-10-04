using Ardalis.Specification;
using School.Domain.Entities;

namespace School.Domain.Specifications.Courses;

public sealed class CourseByIdSpec 
    : Specification<Course>, ISingleResultSpecification
{
    public CourseByIdSpec(CourseFilter filter)
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
