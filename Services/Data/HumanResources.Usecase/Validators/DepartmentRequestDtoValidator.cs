using FluentValidation;
using HumanResources.Core.Shared.Dto.Request;

namespace HumanResources.Usecase.Validators;

public class DepartmentRequestDtoValidator : AbstractValidator<DepartmentRequestDto>
{
    public DepartmentRequestDtoValidator()
    {
        RuleFor(d => d.Name)
            .MinimumLength(3).WithMessage("Department name can't be shorter than 3 characters")
            .MaximumLength(200).WithMessage("Department name can't be longer than 200 characters")
            .NotEmpty();
    }
}
