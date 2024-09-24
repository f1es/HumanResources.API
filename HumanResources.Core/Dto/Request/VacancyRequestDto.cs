namespace HumanResources.Core.Dto.Request;

public record VacancyRequestDto(
	DateTime ReceiptDate,
	string Description,
	Guid ProffesionId);
