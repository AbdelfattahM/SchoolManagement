using AutoMapper;
using MediatR;
using School.Application.Exceptions;
using School.Domain.Entities;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Countries.Commands.UpdateCountry;

public class UpdateCountryRequestHandler
    : IRequestHandler<UpdateCountryRequest>
{
    private readonly IRepository<Country> countryRepository;
    private readonly IMapper _mapper;

    public UpdateCountryRequestHandler(IMapper mapper,
        IRepository<Country> countryRepository)
    {
        _mapper = mapper;
        this.countryRepository = countryRepository;
    }

    public async Task<Unit> Handle(UpdateCountryRequest request,
        CancellationToken cancellationToken)
    {
        var countryToUpdate = await countryRepository.GetByIdAsync(request.Id);

        if (countryToUpdate == null)
        {
            throw new NotFoundException(nameof(Country), request.Id);
        }

        var validator = new UpdateCountryRequestValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        _mapper.Map(request, countryToUpdate, typeof(UpdateCountryRequest),
            typeof(Country));

        await countryRepository.UpdateAsync(countryToUpdate);

        return Unit.Value;
    }
}
