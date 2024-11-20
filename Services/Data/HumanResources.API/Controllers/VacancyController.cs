using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HumanResources.API.Controllers;

[Authorize]
[ApiController]
[Route("api/companies/{companyId:guid}/vacancies")]
public class VacancyController : ControllerBase
{
	private readonly IVacancyService _vacancyService;
	private readonly IWebLogger _webLogger;

	public VacancyController(IVacancyService vacancyService, IWebLogger webLogger)
	{
		_vacancyService = vacancyService;
		_webLogger = webLogger;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll(Guid companyId, [FromQuery] VacancyRequestParameters requestParameters)
	{
		var response = await _vacancyService.GetAllAsync(companyId, requestParameters);

		Response.Headers.Append("Pagination", JsonSerializer.Serialize(response.PagingData));
		await _webLogger.LogInfoAsync($"call api/companies/{companyId}/vacancies GET", Response.StatusCode, User.Claims);

		return Ok(response);
	}

	[HttpGet("{id:guid}", Name = "GetVacancyById")]
	public async Task<IActionResult> GetById(Guid companyId, Guid id)
	{
		var response = await _vacancyService.GetByIdAsync(companyId, id);

		await _webLogger.LogInfoAsync($"call api/companies/{companyId}/vacancies/{id} GET", Response.StatusCode, User.Claims);

		return Ok(response);
	}

	[HttpGet("{id:guid}/profession")]
	public async Task<IActionResult> GetProfession(Guid companyId, Guid id)
	{
		var response = await _vacancyService.GetProfessionByIdAsync(companyId, id);

		await _webLogger.LogInfoAsync($"call api/companies/{companyId}/vacancies/profession GET", Response.StatusCode, User.Claims);

		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> Create(Guid companyId, VacancyRequestDto vacancyDto)
	{
		var response = await _vacancyService.CreateAsync(companyId, vacancyDto);

		await _webLogger.LogInfoAsync($"call api/companies/{companyId}/vacancies POST", Response.StatusCode, User.Claims);

		return CreatedAtRoute("GetVacancyById", new { companyId, id = response.Id }, response);
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Update(Guid companyId, Guid id, VacancyRequestDto vacancyDto)
	{
		await _vacancyService.UpdateAsync(companyId, id, vacancyDto);

		await _webLogger.LogInfoAsync($"call api/companies/{companyId}/vacancies/{id} PUT", Response.StatusCode, User.Claims);

		return NoContent();
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> Delete(Guid companyId, Guid id)
	{
		await _vacancyService.DeleteAsync(companyId, id);

		await _webLogger.LogInfoAsync($"call api/companies/{companyId}/vacancies/{id} DELETE", Response.StatusCode, User.Claims);

		return NoContent();
	}
}
