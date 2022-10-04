using School.Application.Dto;
using School.Application.Responses;

namespace School.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseResponse : BaseResponse

{
    public CreateCourseResponse() : base()
    {

    }

    public CourseDto Course { get; set; }
}
