using MediatR;

namespace School.Application.Features.Students.Commands.UpdateStudent;

public class UpdateStudentRequest : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int CountryId { get; set; }
}
