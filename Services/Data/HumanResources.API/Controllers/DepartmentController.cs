using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HumanResources.API.Controllers;

[Authorize]
[ApiController]
[Route("api/companies/{companyId:guid}/departments")]
public class DepartmentController : ControllerBase
{
	private readonly IDepartmentService _departmentService;
	private readonly IWebLogger _webLogger;

	public DepartmentController(IDepartmentService departmentService, IWebLogger webLogger)
	{
		_departmentService = departmentService;
		_webLogger = webLogger;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll(Guid companyId, [FromQuery] DepartmentRequestParameters requestParameters)
	{
		var response = await _departmentService.GetAllAsync(companyId, requestParameters);

		Response.Headers.Append("Pagination", JsonSerializer.Serialize(response.PagingData));
		await _webLogger.LogInfoAsync($"call api/companies/{companyId}/departments GET", Response.StatusCode, User.Claims);

		return Ok(response);
	}

	[HttpGet("{id:guid}", Name = "GetDepartmentById")]
	public async Task<IActionResult> GetById(Guid companyId, Guid id)
	{
		var response = await _departmentService.GetByIdAsync(companyId, id);

		await _webLogger.LogInfoAsync($"call api/companies/{companyId}/departments/{id} GET", Response.StatusCode, User.Claims);

		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> Create(Guid companyId, DepartmentRequestDto departmentRequest)
	{
		var response = await _departmentService.CreateAsync(companyId, departmentRequest);

		await _webLogger.LogInfoAsync($"call api/companies/{companyId}/departments POST", Response.StatusCode, User.Claims);

		return CreatedAtRoute("GetDepartmentById" , new { companyId, id = response.Id }, response);
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> Delete(Guid companyId, Guid id)
	{
		await _departmentService.DeleteAsync(companyId, id);

		await _webLogger.LogInfoAsync($"call api/companies/{companyId}/departments/{id} DELETE", Response.StatusCode, User.Claims);

		return NoContent();
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Update(Guid companyId, Guid id, DepartmentRequestDto departmentRequest)
	{
		await _departmentService.UpdateAsync(companyId, id, departmentRequest);

		await _webLogger.LogInfoAsync($"call api/companies/{companyId}/departments/{id} PUT", Response.StatusCode, User.Claims);

		return NoContent();
	}
}
