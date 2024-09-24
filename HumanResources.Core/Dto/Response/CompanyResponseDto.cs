namespace HumanResources.Core.Dto.Response;

public record CompanyResponseDto(
	Guid Id,
	string Name,
	DateTime BaseDate);
