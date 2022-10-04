using MediatR;
using School.Application.Dto;

namespace School.Application.Features.Countries.Queries.GetCountries;

public class GetCountriesRequest : IRequest<IReadOnlyList<CountryDto>>
{
    public int? Id { get; set; }
    public string Name { get; set; } = String.Empty;
}
