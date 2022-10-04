using AutoMapper;
using MediatR;
using School.Application.Dto;
using School.Domain.Entities;
using School.Domain.Specifications.Country;
using School.Domain.Specifications.Courses;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Courses.Queries.GetCourses;

public class GetCoursesRequestHandler
    : IRequestHandler<GetCoursesRequest, IReadOnlyList<CourseDto>>
{
    private readonly IReadRepository<Course> courseRepository;
    private readonly IMapper mapper;

    public GetCoursesRequestHandler(IReadRepository<Course> courseRepository,
        IMapper mappper)
    {
        this.mapper = mappper;
        this.courseRepository = courseRepository;
    }

    public async Task<IReadOnlyList<CourseDto>> Handle(GetCoursesRequest request,
        CancellationToken cancellationToken)
    {
        var filter = new CourseFilter
        {
            IsTrackingEnabled = false,
            IsPagingEnabled = true,
            LoadChildren = true
        };
        var spec = new CourseByFilterSpec(filter);
        var allCourses = await courseRepository.ListAsync(spec, cancellationToken);
        return mapper.Map<IReadOnlyList<CourseDto>>(allCourses);
    }
}
