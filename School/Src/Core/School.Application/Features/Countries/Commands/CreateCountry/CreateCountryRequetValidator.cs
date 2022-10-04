using FluentValidation;

namespace School.Application.Features.Countries.Commands.CreateCountry;

public class CreateCountryRequetValidator
    : AbstractValidator<CreateCountryRequest>
{
    public CreateCountryRequetValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
}