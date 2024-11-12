namespace AuthService.Core.Dto.Request;

public record LoginDto(
	string UserName,
	string Password);
