namespace HumanResources.Core.Dto.Response;

public record VacancyResponseDto(
	Guid Id, 
	DateTime ReceiptDate, 
	string Description);
