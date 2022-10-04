namespace School.Application.Contracts.Persistence;

public interface IStudentRepository
{
    public Task<bool> EnrollAsync(params int[] coursesId);
    public Task<bool> UnRegisterAsync(params int[] coursesId);
}
