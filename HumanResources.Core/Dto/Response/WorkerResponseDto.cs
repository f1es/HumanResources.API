namespace HumanResources.Core.Dto.Response;

public record WorkerResponseDto(
	Guid Id,
	string FirstName,
	string LastName,
	string Phone,
	DateTime Birthday);
