using AuthService.Core.Dto.Request;
using AuthService.Core.Dto.Response;
using AuthService.Core.Exceptions;
using AuthService.Core.Models;
using AuthService.Core.Repositories;
using AuthService.Usecase.Services.Interfaces;
using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using IdentityModel.Client;
using Microsoft.EntityFrameworkCore;

namespace AuthService.Usecase.Services.Implementations;

public class UserService : IUserService
{
	private IRepositoryManager _repositoryManager;
	private IMapper _mapper;
	private UserManager<User> _userManager;
	private SignInManager<User> _signInManager;

	public UserService(
		IRepositoryManager repositoryManager,
		IMapper mapper,
		UserManager<User> userManager,
		SignInManager<User> signInManager)
	{
		_repositoryManager = repositoryManager;
		_mapper = mapper;
		_userManager = userManager;
		_signInManager = signInManager;
	}

	public async Task<IdentityResult> CreateAsync(RegisterDto registerDto)
	{
		var userModel = _mapper.Map<User>(registerDto);
		userModel.Id = Guid.NewGuid().ToString();

		var result = await _userManager.CreateAsync(userModel, registerDto.Password);
		await _repositoryManager.SaveAsync();

		return result;
	}

	public async Task DeleteAsync(Guid id)
	{
		var user = await GetUserByIdAndCheckIfExist(id);
		_repositoryManager.UserRepository.Delete(user);
		await _repositoryManager.SaveAsync();
	}

	public async Task<IEnumerable<UserResponseDto>> GetAllAsync()
	{
		var users = await _repositoryManager.UserRepository.GetAllAsync();
		var usersResposne = _mapper.Map<IEnumerable<UserResponseDto>>(users);
		return usersResposne;
	}

	public async Task<UserResponseDto> GetByIdAsync(Guid id)
	{
		var user = await GetUserByIdAndCheckIfExist(id);
		var userResposne = _mapper.Map<UserResponseDto>(user);
		return userResposne;
	}

	public async Task UpdateAsync(Guid id, RegisterDto userDto)
	{
		var userModel = await GetUserByIdAndCheckIfExist(id, trackChanges: true);
		userModel = _mapper.Map(userDto, userModel);
		await _repositoryManager.SaveAsync();
	}

	public async Task<TokenResponse> LoginAsync(LoginDto loginDto)
	{
		var token = await GenerateAccessTokenAsync(loginDto);
		
		return token;
	}

	private async Task<TokenResponse> GenerateAccessTokenAsync(LoginDto loginDto)
	{
		var url = "https://localhost:44387";
		var client = new HttpClient();

		var disco = await client.GetDiscoveryDocumentAsync(url);
		if (disco.IsError)
		{
			throw new Exception(disco.Error);
		}

		var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
		{
			Address = disco.TokenEndpoint,
			ClientId = "wpf_client",
			Scope = "openid profile api1",
			UserName = loginDto.UserName,
			Password = loginDto.Password
		});

		if (tokenResponse.IsError)
		{
			throw new Exception(tokenResponse.Error);
		}

		return tokenResponse;
	}
	

	private async Task<User> GetUserByIdAndCheckIfExist(Guid id, bool trackChanges = false)
	{
		var user = await _repositoryManager.UserRepository.GetByIdAsync(id, trackChanges);

		if (user is null)
			throw new NotFoundException($"User with id {id} not found");

		return user;
	}
}
