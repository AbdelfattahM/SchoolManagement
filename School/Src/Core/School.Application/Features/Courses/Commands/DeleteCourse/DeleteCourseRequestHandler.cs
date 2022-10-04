using AutoMapper;
using MediatR;
using School.Application.Exceptions;
using School.Domain.Entities;
using School.SharedKernel.Interfaces;

namespace School.Application.Features.Courses.Commands.DeleteCourse;

public class DeleteCourseRequestHandler 
    : IRequestHandler<DeleteCourseRequest>
{
    private readonly IRepository<Course> courseRepository;
    private readonly IMapper mapper;

    public DeleteCourseRequestHandler(IMapper mapper, 
        IRepository<Course> courseRepository)
    {
        this.mapper = mapper;
        this.courseRepository = courseRepository;
    }

    public async Task<Unit> Handle(DeleteCourseRequest request,
        CancellationToken cancellationToken)
    {
        var countryToDelete = await courseRepository.GetByIdAsync(request.Id);

        if (countryToDelete == null)
        {
            throw new NotFoundException(nameof(Course), request.Id);
        }

        await courseRepository.DeleteAsync(countryToDelete);

        return Unit.Value;
    }
}
