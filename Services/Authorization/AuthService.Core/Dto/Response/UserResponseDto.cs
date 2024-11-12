namespace AuthService.Core.Dto.Response;

public record UserResponseDto(
	string Id,
	string UserName,
	string FirstName,
	string LastName);
