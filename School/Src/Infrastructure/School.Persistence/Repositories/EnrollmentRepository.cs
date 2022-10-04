using School.Application.Contracts.Persistence;
using School.Domain.Entities;

namespace School.Persistence.Repositories;

public class EnrollmentRepository
   : BaseRepository<Enrollment>, IEnrollmentRepository
{
    public EnrollmentRepository(SchoolContext dbContext) : base(dbContext)
    {

    }
}
