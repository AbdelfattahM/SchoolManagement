using School.Application.Dto;
using School.Application.Responses;

namespace School.Application.Features.Students.Commands.CreateStudent;

public class CreateStudentResponse : BaseResponse

{
    public CreateStudentResponse() : base()
    {

    }

    public StudentDto Student { get; set; }
}