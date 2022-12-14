using FluentValidation;

namespace School.Application.Features.Countries.Commands.UpdateCountry;

public class UpdateCountryRequestValidator 
    : AbstractValidator<UpdateCountryRequest>
{
    public UpdateCountryRequestValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required.")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");
    }
}
