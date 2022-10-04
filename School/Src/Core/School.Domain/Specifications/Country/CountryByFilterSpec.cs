using Ardalis.Specification;
using School.Domain.Specifications.Helpers;

namespace School.Domain.Specifications.Country;

public sealed class CountryByFilterSpec 
    : Specification<School.Domain.Entities.Country>
{
    public CountryByFilterSpec(CountryFilter filter)
    {
        if (!filter.IsTrackingEnabled)
        {
            Query.AsNoTracking();
        }

        if (filter.LoadChildren)
        {
            Query.Include(x => x.Students);
        }

        if (filter.IsPagingEnabled)
        {
            Query
              .Skip(PaginationHelper.CalculateSkip(filter))
              .Take(PaginationHelper.CalculateTake(filter));
        }

        if (filter.Id != null)
        {
            Query.Where(b => b.Id == filter.Id);
        }

        if (!string.IsNullOrEmpty(filter.Name))
        {
            Query.Search(b => b.Name, $"% {filter.Name} %");
        }

        Query.OrderBy(b => b.Id);
    }
}
