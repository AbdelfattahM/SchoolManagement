using MediatR;
using Microsoft.AspNetCore.Mvc;
using School.Application.Dto;
using School.Application.Features.Students.Commands.CreateStudent;
using School.Application.Features.Students.Commands.DeleteStudent;
using School.Application.Features.Students.Commands.UpdateStudent;
using School.Application.Features.Students.Queries.GetStudentById;
using School.Application.Features.Students.Queries.GetStudents;

namespace School.ApiCore.Controllers;

[Route("api/student")]
[ApiController]
public class StudentController : ControllerBase
{
    private readonly IMediator _mediator;

    public StudentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("all", Name = "GetAllStudents")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IReadOnlyList<StudentDto>>> GetAllStudents()
    {
        var dtos = await _mediator.Send(new GetStudentsRequest());
        return Ok(dtos);
    }

    [HttpGet("{id:int}", Name = "GetStudentById")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<StudentDto>> GetStudentById(int Id)
    {
        var getStudentByIdRequest = new GetStudentByIdRequest() { Id = Id };

        return Ok(await _mediator.Send(getStudentByIdRequest));
    }

    [HttpPost(Name = "CreateStudent")]
    public async Task<ActionResult<CreateStudentResponse>> Create(
            [FromBody] CreateStudentRequest createStudentRequest)
    {
        var response = await _mediator.Send(createStudentRequest);
        return Ok(response);
    }

    [HttpPut(Name = "UpdateStudent")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Update(
        [FromBody] UpdateStudentRequest updateStudentRequest)
    {
        await _mediator.Send(updateStudentRequest);
        return NoContent();
    }

    [HttpDelete("{id}", Name = "DeleteStudent")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        var deleteCountryRequest = new DeleteStudentRequest() { Id = id };
        await _mediator.Send(deleteCountryRequest);
        return NoContent();
    }
}