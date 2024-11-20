using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HumanResources.API.Controllers;

[Authorize]
[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
	private readonly ICompanyService _companyService;
	private readonly IWebLogger _webLogger;

	public CompanyController(ICompanyService companyService, IWebLogger webLogger)
	{
		_companyService = companyService;
		_webLogger = webLogger;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] CompanyRequestParameters requestParameters)
	{
		var response = await _companyService.GetAllAsync(requestParameters);

		Response.Headers.Append("Pagination", JsonSerializer.Serialize(response.PagingData));
		await _webLogger.LogInfoAsync("call api/companies GET", Response.StatusCode, User.Claims);

		return Ok(response);
	}

	[HttpGet("{id:guid}", Name = "GetCompanyById")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var response = await _companyService.GetByIdAsync(id);

		await _webLogger.LogInfoAsync($"call api/companies/{id} GET", Response.StatusCode, User.Claims);

		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> Create(CompanyRequestDto company)
	{
		var response = await _companyService.CreateAsync(company);

		await _webLogger.LogInfoAsync("call api/companies POST", Response.StatusCode, User.Claims);

		return CreatedAtRoute("GetCompanyById", new { id = response.Id}, response);
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _companyService.DeleteAsync(id);

		await _webLogger.LogInfoAsync($"call api/companies/{id} DELETE", Response.StatusCode, User.Claims);

		return NoContent();
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Update(Guid id, CompanyRequestDto company)
	{
		await _companyService.UpdateAsync(id, company);

		await _webLogger.LogInfoAsync($"call api/companies/{id} PUT", Response.StatusCode, User.Claims);

		return NoContent();
	}
}
