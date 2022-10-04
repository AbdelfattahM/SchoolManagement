using FluentValidation;
using School.Application.Features.Students.Commands.CreateStudent;

namespace School.Application.Features.Courses.Commands.CreateCourse;

public class CreateCourseRequetValidator 
    : AbstractValidator<CreateCourseRequest>
{
    public CreateCourseRequetValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
}
