using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HumanResources.API.Controllers;

//[Authorize]
[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
	private readonly ICompanyService _companyService;

	public CompanyController(ICompanyService companyService)
	{
		_companyService = companyService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] CompanyRequestParameters requestParameters)
	{
		var response = await _companyService.GetAllAsync(requestParameters);

		Response.Headers.Append("Pagination", JsonSerializer.Serialize(response.PagingData));

		return Ok(response);
	}

	[HttpGet("{id:guid}", Name = "GetCompanyById")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var response = await _companyService.GetByIdAsync(id);

		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> Create(CompanyRequestDto company)
	{
		var response = await _companyService.CreateAsync(company);

		return CreatedAtRoute("GetCompanyById", new { id = response.Id}, response);
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		await _companyService.DeleteAsync(id);

		return NoContent();
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Update(Guid id, CompanyRequestDto company)
	{
		await _companyService.UpdateAsync(id, company);

		return NoContent();
	}
}
