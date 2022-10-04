using Ardalis.Specification;

namespace School.Domain.Specifications.Country;

public sealed class CountryByIdSpec 
    : Specification<School.Domain.Entities.Country>, ISingleResultSpecification
{
    public CountryByIdSpec(CountryFilter filter)
    {
        if (!filter.IsTrackingEnabled)
        {
            Query.AsNoTracking();
        }

        if (filter.LoadChildren)
        {
            Query.Include(x=>x.Students);
        }

        if (filter.Id != null)
        {
            Query.Where(b => b.Id == filter.Id);
        }

        Query.OrderBy(b => b.Id);
    }
}
