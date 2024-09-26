using FluentValidation;
using HumanResources.Core.Shared.Dto.Request;

namespace HumanResources.Usecase.Validators;

public class ProfessionRequestDtoValidator : AbstractValidator<ProfessionRequestDto>
{
    public ProfessionRequestDtoValidator()
    {
        RuleFor(p => p.Name)
            .MinimumLength(3).WithMessage("Profession name can't be shorter than 3 characters")
            .MaximumLength(200).WithMessage("Department name can't be longer than 200 characters")
            .NotEmpty();

        RuleFor(p => p.Salary)
            .GreaterThanOrEqualTo(1).WithMessage("Salary can't be smaller than 1")
            .NotEmpty();
    }
}
