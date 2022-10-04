using AutoMapper;
using MediatR;
using School.Application.Dto;
using School.Application.Exceptions;
using School.Domain.Entities;
using School.Domain.Specifications.Students;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Students.Queries.GetStudentById;

public class GetStudentByIdRequestHandler : IRequestHandler<GetStudentByIdRequest, StudentDto>
{
    private readonly IReadRepository<Student> studentRepository;
    private readonly IMapper mapper;

    public GetStudentByIdRequestHandler(IReadRepository<Student> studentRepository,
        IMapper mappper)
    {
        this.mapper = mappper;
        this.studentRepository = studentRepository;
    }

    public async Task<StudentDto> Handle(GetStudentByIdRequest request,
        CancellationToken cancellationToken)
    {

        if (request.Id < 0)
        {
            throw new BadRequestException($"Invalid Course ID: {request.Id}");
        }

        var filter = new StudentFilter
        {
            Id = request.Id,
            IsTrackingEnabled = false,
            IsPagingEnabled = true,
            LoadChildren = true
        };
        var spec = new StudentByFilterSpec(filter);
        var course = await studentRepository.GetBySpecAsync(spec, cancellationToken);
        if (course == null)
        {
            throw new NotFoundException(nameof(Student), request.Id);
        }
        return mapper.Map<StudentDto>(course);
    }
}