using School.Application.Dto;
using School.Application.Responses;

namespace School.Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryResponse : BaseResponse

{
    public CreateCountryResponse() : base()
    {

    }

    public CountryDto Country { get; set; }
}