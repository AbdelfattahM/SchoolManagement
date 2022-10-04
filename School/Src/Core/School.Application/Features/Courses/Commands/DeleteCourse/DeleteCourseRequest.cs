using MediatR;

namespace School.Application.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseRequest : IRequest
{
    public int Id { get; set; }
}
