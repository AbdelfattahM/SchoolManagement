using MediatR;

namespace School.Application.Features.Students.Commands.DeleteStudent;

public class DeleteStudentRequest : IRequest
{
    public int Id { get; set; }
}
