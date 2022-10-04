using AutoMapper;
using MediatR;
using School.Application.Exceptions;
using School.Application.Features.Countries.Commands.UpdateCountry;
using School.Domain.Entities;
using School.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.Features.Courses.Commands.UpdateCourse;

public class UpdateCourseRequestHandler : IRequestHandler<UpdateCourseRequest>
{
    private readonly IRepository<Course> courseRepository;
    private readonly IMapper _mapper;

    public UpdateCourseRequestHandler(IMapper mapper,
        IRepository<Course> courseRepository)
    {
        _mapper = mapper;
        this.courseRepository = courseRepository;
    }

    public async Task<Unit> Handle(UpdateCourseRequest request,
        CancellationToken cancellationToken)
    {
        var courseToUpdate = await courseRepository.GetByIdAsync(request.Id);

        if (courseToUpdate == null)
        {
            throw new NotFoundException(nameof(Course), request.Id);
        }

        var validator = new UpdateCourseRequestValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
            throw new ValidationException(validationResult);

        _mapper.Map(request, courseToUpdate, typeof(UpdateCourseRequest),
            typeof(Course));

        await courseRepository.UpdateAsync(courseToUpdate);

        return Unit.Value;
    }
}

