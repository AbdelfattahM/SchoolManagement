using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.Dto;
using School.Application.Features.Countries.Commands.CreateCountry;
using School.Application.Features.Countries.Commands.DeleteCountry;
using School.Application.Features.Countries.Commands.UpdateCountry;
using School.Application.Features.Countries.Queries.GetCountries;
using School.Application.Features.Countries.Queries.GetCountryById;

namespace School.ApiCore.Controllers
{
    [Route("api/country")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCountries")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<CountryDto>>> GetAllCountries()
        {
            var dtos = await _mediator.Send(new GetCountriesRequest());
            return Ok(dtos);
        }

        [HttpGet("{id:int}", Name = "GetCountryById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CountryDto>> GetCountryById(int Id)
        {
            var getCountryByIdRequest = new GetCountryByIdRequest() { Id = Id };

            return Ok(await _mediator.Send(getCountryByIdRequest));
        }

        [HttpPost(Name = "CreateCountry")]
        public async Task<ActionResult<CreateCountryResponse>> Create(
            [FromBody] CreateCountryRequest createCountryRequest)
        {
            var response = await _mediator.Send(createCountryRequest);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateCountry")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(
            [FromBody] UpdateCountryRequest updateCountryRequest)
        {
            await _mediator.Send(updateCountryRequest);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCountry")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCountryRequest = new DeleteCountryRequest() { Id = id };
            await _mediator.Send(deleteCountryRequest);
            return NoContent();
        }
    }
}
