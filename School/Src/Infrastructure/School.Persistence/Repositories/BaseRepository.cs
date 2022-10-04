using Ardalis.Specification.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Application.Contracts.Persistence;
using School.SharedKernel.Interfaces;

namespace School.Persistence.Repositories;

public class BaseRepository<T> 
    : RepositoryBase<T>, IReadRepository<T>, IRepository<T>
    where T : class
{
    protected readonly SchoolContext _dbContext;

    public BaseRepository(SchoolContext dbcontext) : base(dbcontext)
    {
        _dbContext = dbcontext;
    }
}
