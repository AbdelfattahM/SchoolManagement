using MediatR;

namespace School.Application.Features.Countries.Commands.UpdateCountry;

public class UpdateCountryRequest : IRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
}
