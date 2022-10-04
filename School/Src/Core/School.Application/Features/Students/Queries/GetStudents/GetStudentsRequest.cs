using MediatR;
using School.Application.Dto;

namespace School.Application.Features.Students.Queries.GetStudents;

public class GetStudentsRequest : IRequest<IReadOnlyList<StudentDto>>
{
    public int? Id { get; set; }
    public string Name { get; set; } = String.Empty;
}
