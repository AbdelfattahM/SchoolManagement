using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.Dto;
using School.Application.Features.Courses.Commands.CreateCourse;
using School.Application.Features.Courses.Commands.DeleteCourse;
using School.Application.Features.Courses.Commands.UpdateCourse;
using School.Application.Features.Courses.Queries.GetCourseById;
using School.Application.Features.Courses.Queries.GetCourses;

namespace School.ApiCore.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CoursesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCourses")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<CourseDto>>> GetAllCourses()
        {
            var dtos = await _mediator.Send(new GetCoursesRequest());
            return Ok(dtos);
        }

        [HttpGet("{id:int}", Name = "GetCourseById")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<CourseDto>> GetCourseById(int Id)
        {
            var getCourseByIdRequest = new GetCourseByIdRequest() { Id = Id };

            return Ok(await _mediator.Send(getCourseByIdRequest));
        }

        [HttpPost(Name = "CreateCourse")]
        public async Task<ActionResult<CreateCourseResponse>> Create(
            [FromBody] CreateCourseRequest createCourseRequest)
        {
            var response = await _mediator.Send(createCourseRequest);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateCourse")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update(
            [FromBody] UpdateCourseRequest updateCourseRequest)
        {
            await _mediator.Send(updateCourseRequest);
            return NoContent();
        }

        [HttpDelete("{id}", Name = "DeleteCourse")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(int id)
        {
            var deleteCountryRequest = new DeleteCourseRequest() { Id = id };
            await _mediator.Send(deleteCountryRequest);
            return NoContent();
        }
    }
}
