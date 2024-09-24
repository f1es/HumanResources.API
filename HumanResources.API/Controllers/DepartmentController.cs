using HumanResources.Core.Dto.Request;
using HumanResources.Usecase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HumanResources.API.Controllers;

[ApiController]
[Route("api/companies/{companyId:guid}/departments")]
public class DepartmentController : ControllerBase
{
	private readonly IDepartmentService _departmentService;

	public DepartmentController(IDepartmentService departmentService)
	{
		_departmentService = departmentService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll(Guid companyId)
	{
		var response = await _departmentService.GetAllAsync(companyId);

		return Ok(response);
	}

	[HttpGet("{id:guid}", Name = "GetDepartmentById")]
	public async Task<IActionResult> GetById(Guid companyId, Guid id)
	{
		var response = await _departmentService.GetByIdAsync(companyId, id);

		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> Create(Guid companyId, DepartmentRequestDto departmentRequest)
	{
		var response = await _departmentService.CreateAsync(companyId, departmentRequest);

		return CreatedAtRoute("GetDepartmentById" , new { companyId, id = response.Id }, response);
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> Delete(Guid companyId, Guid id)
	{
		await _departmentService.DeleteAsync(companyId, id);

		return NoContent();
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Update(Guid companyId, Guid id, DepartmentRequestDto departmentRequest)
	{
		await _departmentService.UpdateAsync(companyId, id, departmentRequest);

		return NoContent();
	}
}
