using FluentValidation;
using HumanResources.Core.Dto.Request;

namespace HumanResources.Usecase.Validators;

public class VacancyRequestDtoValidator : AbstractValidator<VacancyRequestDto>
{
    public VacancyRequestDtoValidator()
    {
        RuleFor(v => v.ReceiptDate)
            .NotEmpty().WithMessage("Receipt date can't be empty");

        RuleFor(v => v.Description)
            .MaximumLength(500).WithMessage("Description can't be longer than 500 characters");
    }
}
