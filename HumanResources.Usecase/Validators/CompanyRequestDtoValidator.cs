using FluentValidation;
using HumanResources.Core.Dto.Request;

namespace HumanResources.Usecase.Validators;

public class CompanyRequestDtoValidator : AbstractValidator<CompanyRequestDto>
{
    public CompanyRequestDtoValidator()
    {
        RuleFor(c => c.Name)
            .MinimumLength(3).WithMessage("Company name can't be shorter than 3 characters")
            .MaximumLength(200).WithMessage("Company name can't be longer than 200 characters")
            .NotEmpty();

        RuleFor(c => c.BaseDate)
            .NotEmpty().WithMessage("Base date can't be empty");
    }
}
