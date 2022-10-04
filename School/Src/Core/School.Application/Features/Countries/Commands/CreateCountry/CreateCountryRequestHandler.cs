using AutoMapper;
using MediatR;
using School.Application.Dto;
using School.Domain.Entities;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryRequestHandler
    : IRequestHandler<CreateCountryRequest, CreateCountryResponse>
{
    private readonly IRepository<Country> countryRepository;
    private readonly IMapper _mapper;

    public CreateCountryRequestHandler(IMapper mapper,
        IRepository<Country> countryRepository)
    {
        _mapper = mapper;
        this.countryRepository = countryRepository;
    }

    public async Task<CreateCountryResponse> Handle(CreateCountryRequest request,
            CancellationToken cancellationToken)
    {
        var createCountryResponse = new CreateCountryResponse();

        var validator = new CreateCountryRequetValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            createCountryResponse.Success = false;
            createCountryResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                createCountryResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (createCountryResponse.Success)
        {
            var country = new Country() { Name = request.Name };
            var countryEntity = await countryRepository.AddAsync(country);
            createCountryResponse.Country = _mapper.Map<CountryDto>(countryEntity);
        }

        return createCountryResponse;
    }
}
