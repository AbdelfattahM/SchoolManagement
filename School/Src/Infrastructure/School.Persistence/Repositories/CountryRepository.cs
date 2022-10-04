using School.Application.Contracts.Persistence;
using School.Domain.Entities;
using School.SharedKernel.Interfaces;

namespace School.Persistence.Repositories;

public class CountryRepository : BaseRepository<Country>, ICountryRepository
{
    private readonly SchoolContext dbContext;

    public CountryRepository(SchoolContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}
