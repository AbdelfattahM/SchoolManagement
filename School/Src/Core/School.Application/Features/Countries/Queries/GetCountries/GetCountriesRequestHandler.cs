using AutoMapper;
using MediatR;
using School.Application.Dto;
using School.Domain.Entities;
using School.Domain.Specifications.Country;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Countries.Queries.GetCountries;

public class GetCountriesRequestHandler
    : IRequestHandler<GetCountriesRequest, IReadOnlyList<CountryDto>>
{
    private readonly IReadRepository<Country> countryRepository;
    private readonly IMapper mapper;

    public GetCountriesRequestHandler(IReadRepository<Country> countryRepository,
        IMapper mappper)
    {
        this.mapper = mappper;
        this.countryRepository = countryRepository;
    }

    public async Task<IReadOnlyList<CountryDto>> Handle(GetCountriesRequest request,
        CancellationToken cancellationToken)
    {
        var filter = new CountryFilter
        {
            Id = request.Id,
            Name = request.Name,
            IsTrackingEnabled = false,
            IsPagingEnabled = true,
            LoadChildren = true
        };
        var spec = new CountryByFilterSpec(filter);
        var allCountries = await countryRepository.ListAsync(spec, cancellationToken);
        return mapper.Map<IReadOnlyList<CountryDto>>(allCountries);
    }
}
