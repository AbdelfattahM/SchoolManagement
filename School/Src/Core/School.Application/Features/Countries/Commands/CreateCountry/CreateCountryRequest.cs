using MediatR;

namespace School.Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryRequest : IRequest<CreateCountryResponse>
{
    public string Name { get; set; }
}
