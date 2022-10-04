using MediatR;
using School.Application.Dto;
using System.ComponentModel.DataAnnotations;

namespace School.Application.Features.Students.Queries.GetStudentById;

public class GetStudentByIdRequest : IRequest<StudentDto>
{
    [Required]
    public int Id { get; set; }
}