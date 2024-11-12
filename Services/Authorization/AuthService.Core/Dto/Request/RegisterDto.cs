namespace AuthService.Core.Dto.Request;

public record RegisterDto(
	string UserName, 
	string Password,
	string FirstName,
	string LastName);