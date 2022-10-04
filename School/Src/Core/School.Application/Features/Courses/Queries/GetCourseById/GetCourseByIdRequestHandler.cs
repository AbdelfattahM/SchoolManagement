using AutoMapper;
using MediatR;
using School.Application.Dto;
using School.Application.Exceptions;
using School.Domain.Entities;
using School.Domain.Specifications.Courses;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Courses.Queries.GetCourseById;

public class GetCourseByIdRequestHandler
     : IRequestHandler<GetCourseByIdRequest, CourseDto>
{
    private readonly IReadRepository<Course> courseRepository;
    private readonly IMapper mapper;

    public GetCourseByIdRequestHandler(IReadRepository<Course> courseRepository,
        IMapper mappper)
    {
        this.mapper = mappper;
        this.courseRepository = courseRepository;
    }

    public async Task<CourseDto> Handle(GetCourseByIdRequest request,
        CancellationToken cancellationToken)
    {

        if(request.Id <0)
        {
            throw new BadRequestException($"Invalid Course ID: {request.Id}");
        }

        var filter = new CourseFilter
        {
            Id = request.Id,
            IsTrackingEnabled = false,
            IsPagingEnabled = true,
            LoadChildren = true
        };
        var spec = new CourseByFilterSpec(filter);
        var course = await courseRepository.GetBySpecAsync(spec, cancellationToken);
        if(course == null)
        {
            throw new NotFoundException(nameof(Course), request.Id);
        }
        return mapper.Map<CourseDto>(course);
    }
}
