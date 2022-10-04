using School.Domain.Entities;

namespace School.UIBlazor.Contracts;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllCourses();
    Task<Course> GetCourseDetails(int courseId);
    Task<Course> AddCourse(Course course);
    Task UpdateCourse(Course course);
    Task DeleteCourse(int courseId);
}
