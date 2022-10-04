using MediatR;
using School.Application.Dto;
using System.ComponentModel.DataAnnotations;

namespace School.Application.Features.Courses.Queries.GetCourseById;

public class GetCourseByIdRequest : IRequest<CourseDto>
{
    [Required]
    public int Id { get; set; }
}
