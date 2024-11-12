using AuthService.Core.Dto.Request;
using AuthService.Core.Models;
using AuthService.Usecase.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.API.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController : ControllerBase
{
	private IUserService _userService;

	public AccountController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var users = await _userService.GetAllAsync();

		return Ok(users);
	}
	[HttpGet("{id:guid}", Name = "GetUserById")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var user = await _userService.GetByIdAsync(id);

		return Ok(user);
	}

	[HttpPost("register")]
	public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
	{
		var response = await _userService.CreateAsync(registerDto);

		return Ok(response);
	}

	[HttpPost("login")]
	public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
	{
		var token = await _userService.LoginAsync(loginDto);

		return Ok(token);
	}
}
