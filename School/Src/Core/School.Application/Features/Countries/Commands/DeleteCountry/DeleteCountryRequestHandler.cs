using AutoMapper;
using MediatR;
using School.Application.Exceptions;
using School.Domain.Entities;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Countries.Commands.DeleteCountry;

public class DeleteCountryRequestHandler :
   IRequestHandler<DeleteCountryRequest>
{
    private readonly IRepository<Country> countryRepository;
    private readonly IMapper mapper;

    public DeleteCountryRequestHandler(IMapper mapper, IRepository<Country> eventRepository)
    {
        this.mapper = mapper;
        countryRepository = eventRepository;
    }

    public async Task<Unit> Handle(DeleteCountryRequest request,
        CancellationToken cancellationToken)
    {
        var countryToDelete = await countryRepository.GetByIdAsync(request.Id);

        if (countryToDelete == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }

        await countryRepository.DeleteAsync(countryToDelete);

        return Unit.Value;
    }
}
