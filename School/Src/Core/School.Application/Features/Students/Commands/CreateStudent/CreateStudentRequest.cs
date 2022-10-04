using MediatR;

namespace School.Application.Features.Students.Commands.CreateStudent;

public class CreateStudentRequest : IRequest<CreateStudentResponse>
{
    public string Name { get; set; }
}

