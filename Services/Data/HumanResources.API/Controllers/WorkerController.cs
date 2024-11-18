using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HumanResources.API.Controllers;

//[Authorize]
[ApiController]
[Route("api/companies/{companyId:guid}/departments/{departmentId:guid}/workers")]
public class WorkerController : ControllerBase
{
	private readonly IWorkerService _workerService;

	public WorkerController(IWorkerService workerService)
	{
		_workerService = workerService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll(Guid companyId, Guid departmentId, [FromQuery] WorkerRequestParameters requestParameters)
	{
		var response = await _workerService.GetAllAsync(companyId, departmentId, requestParameters);

		Response.Headers.Append("Pagination", JsonSerializer.Serialize(response.PagingData));

		return Ok(response);
	}

	[HttpGet("{id:guid}", Name = "GetWorkerById")]
	public async Task<IActionResult> GetById(Guid companyId, Guid departmentId, Guid id)
	{
		var response = await _workerService.GetByIdAsync(companyId, departmentId, id);

		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> Create(Guid companyId, Guid departmentId, WorkerRequestDto workerDto)
	{
		var response = await _workerService.CreateAsync(companyId, departmentId, workerDto);

		return CreatedAtRoute("GetWorkerById", new { companyId, departmentId, id = response.Id }, response);
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Update(Guid companyId, Guid departmentId, Guid id, WorkerRequestDto workerDto)
	{
		await _workerService.UpdateAsync(companyId, departmentId, id, workerDto);

		return NoContent();
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> Delete(Guid companyId, Guid departmentId, Guid id)
	{
		await _workerService.DeleteAsync(companyId, departmentId, id);

		return NoContent();
	}
}
