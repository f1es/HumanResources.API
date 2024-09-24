namespace HumanResources.Core.Dto.Response;

public record ProfessionResponseDto(
	Guid Id, 
	string Name, 
	decimal Salary);
