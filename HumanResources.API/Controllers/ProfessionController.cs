using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HumanResources.API.Controllers;

[ApiController]
[Route("api/professions")]
public class ProfessionController : ControllerBase
{
	private readonly IProfessionService _professionService;

	public ProfessionController(IProfessionService professionService)
	{
		_professionService = professionService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] ProfessionRequestParameters requestParameters)
	{
		var response = await _professionService.GetAllAsync(requestParameters);

		Response.Headers.Append("Pagination", JsonSerializer.Serialize(response.PagingData));

		return Ok(response);
	}

	[HttpGet("{id:guid}", Name = "GetProfessionById")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var response = await _professionService.GetByIdAsync(id);

		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> Create(ProfessionRequestDto professionDto)
	{
		var response = await _professionService.CreateAsync(professionDto);

		return CreatedAtRoute("GetProfessionById", new { id = response.Id }, response);
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Update(Guid id, ProfessionRequestDto professionDto)
	{
		await _professionService.UpdateAsync(id, professionDto);

		return NoContent();
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _professionService.DeleteAsync(id);

		return NoContent();
	}
}
