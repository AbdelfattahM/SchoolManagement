using MediatR;

namespace School.Application.Features.Countries.Commands.DeleteCountry;

public class DeleteCountryRequest : IRequest
{
    public int Id { get; set; }
}
