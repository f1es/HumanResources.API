using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HumanResources.API.Controllers;

[Authorize]
[ApiController]
[Route("api/professions")]
public class ProfessionController : ControllerBase
{
	private readonly IProfessionService _professionService;
	private readonly IWebLogger _webLogger;
	public ProfessionController(IProfessionService professionService, IWebLogger webLogger)
	{
		_professionService = professionService;
		_webLogger = webLogger;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] ProfessionRequestParameters requestParameters)
	{
		var response = await _professionService.GetAllAsync(requestParameters);

		Response.Headers.Append("Pagination", JsonSerializer.Serialize(response.PagingData));
		await _webLogger.LogInfoAsync("call api/professions GET", Response.StatusCode, User.Claims);

		return Ok(response);
	}

	[HttpGet("{id:guid}", Name = "GetProfessionById")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var response = await _professionService.GetByIdAsync(id);
		await _webLogger.LogInfoAsync($"call api/professions/{id} GET", Response.StatusCode, User.Claims);

		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> Create(ProfessionRequestDto professionDto)
	{
		var response = await _professionService.CreateAsync(professionDto);

		await _webLogger.LogInfoAsync($"call api/professions POST", Response.StatusCode, User.Claims);

		return CreatedAtRoute("GetProfessionById", new { id = response.Id }, response);
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Update(Guid id, ProfessionRequestDto professionDto)
	{
		await _professionService.UpdateAsync(id, professionDto);

		await _webLogger.LogInfoAsync($"call api/professions/{id} PUT", Response.StatusCode, User.Claims);

		return NoContent();
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _professionService.DeleteAsync(id);

		await _webLogger.LogInfoAsync($"call api/professions/{id} DELETE", Response.StatusCode, User.Claims);

		return NoContent();
	}
}
