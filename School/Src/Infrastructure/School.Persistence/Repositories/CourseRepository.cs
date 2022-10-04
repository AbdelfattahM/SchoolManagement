using School.Application.Contracts.Persistence;
using School.Domain.Entities;

namespace School.Persistence.Repositories;

public class CourseRepository
    : BaseRepository<Course>, ICourseRepository
{
    public CourseRepository(SchoolContext dbContext) : base(dbContext)
    {

    }
}
