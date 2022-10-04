using MediatR;

namespace School.Application.Features.Courses.Commands.CreateCourse
{
    public class CreateCourseRequest : IRequest<CreateCourseResponse>
    {
        public string Name { get; set; }
    }
}
