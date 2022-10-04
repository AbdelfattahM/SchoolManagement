using AutoMapper;
using MediatR;
using School.Application.Dto;
using School.Application.Exceptions;
using School.Application.Features.Countries.Queries.GetCountries;
using School.Domain.Entities;
using School.Domain.Specifications.Country;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Countries.Queries.GetCountryById;

public class GetCountryByIdRequestHandler
    :IRequestHandler<GetCountryByIdRequest, CountryDto>
{
    private readonly IReadRepository<Country> countryRepository;
    private readonly IMapper mapper;

    public GetCountryByIdRequestHandler(IReadRepository<Country> countryRepository,
        IMapper mappper)
    {
        this.mapper = mappper;
        this.countryRepository = countryRepository;
    }

    public async Task<CountryDto> Handle(GetCountryByIdRequest request,
        CancellationToken cancellationToken)
    {
        var filter = new CountryFilter
        {
            Id = request.Id,
            IsTrackingEnabled = false,
            IsPagingEnabled = false,
            LoadChildren = true
        };
        var spec = new CountryByFilterSpec(filter);
        Country? country = await countryRepository.GetBySpecAsync(spec, cancellationToken);
        if(country == null)
        {
            throw new NotFoundException(nameof(country),request.Id);
        }
        return mapper.Map<CountryDto>(country);
    }
}
