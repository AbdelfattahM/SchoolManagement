using School.Application.Contracts.Persistence;
using School.Domain.Entities;

namespace School.Persistence.Repositories
{
    public class StudentRepository
        : BaseRepository<Student> , IStudentRepository
    {
        public StudentRepository(SchoolContext dbContext) : base(dbContext)
        {

        }

        public Task<bool> EnrollAsync(params int[] coursesId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UnRegisterAsync(params int[] coursesId)
        {
            throw new NotImplementedException();
        }
    }
}
