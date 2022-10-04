using School.Domain.Entities;

namespace School.UIBlazor.Contracts;

public interface IStudentsService
{
    Task<IEnumerable<Student>> GetAllStudents();
    Task<Student> GetStudentDetails(int studentId);
    Task<Student> AddStudent(Student student);
    Task UpdateStudent(Student student);
    Task DeleteStudent(int studentId);
}
