using MediatR;
using School.Application.Dto;

namespace School.Application.Features.Courses.Queries.GetCourses;

public class GetCoursesRequest : IRequest<IReadOnlyList<CourseDto>>
{
    public int? Id { get; set; }
    public string Name { get; set; } = String.Empty;
}
