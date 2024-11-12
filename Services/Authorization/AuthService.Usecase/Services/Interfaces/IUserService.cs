using AuthService.Core.Dto.Request;
using AuthService.Core.Dto.Response;
using AuthService.Core.Models;
using IdentityModel.Client;
using Microsoft.AspNetCore.Identity;

namespace AuthService.Usecase.Services.Interfaces;

public interface IUserService
{
	public Task<IdentityResult> CreateAsync(RegisterDto user);
	public Task UpdateAsync(Guid id, RegisterDto user);
	public Task DeleteAsync(Guid id);
	public Task<UserResponseDto> GetByIdAsync(Guid id);
	public Task<IEnumerable<UserResponseDto>> GetAllAsync();
	public Task<TokenResponse> LoginAsync(LoginDto loginDto);
}
