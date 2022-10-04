using MediatR;

namespace School.Application.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseRequest : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
