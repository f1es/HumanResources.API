namespace HumanResources.Core.Dto.Request;

public record WorkerRequestDto(
	string FirstName,
	string LastName,
	string Phone,
	DateTime Birthday);
