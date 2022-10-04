using FluentValidation;
using School.Application.Features.Countries.Commands.CreateCountry;

namespace School.Application.Features.Students.Commands.CreateStudent;

public class CreateStudentRequetValidator 
    : AbstractValidator<CreateStudentRequest>
{
    public CreateStudentRequetValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
}
