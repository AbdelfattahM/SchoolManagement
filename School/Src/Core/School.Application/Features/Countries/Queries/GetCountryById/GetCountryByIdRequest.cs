using MediatR;
using School.Application.Dto;
using System.ComponentModel.DataAnnotations;

namespace School.Application.Features.Countries.Queries.GetCountryById;

public class GetCountryByIdRequest : IRequest<CountryDto>
{
    [Required]
    public int Id { get; set; }
}
