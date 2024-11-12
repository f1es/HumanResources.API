﻿using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HumanResources.API.Controllers;

[ApiController]
[Route("api/companies/{companyId:guid}/vacancies")]
public class VacancyController : ControllerBase
{
	private readonly IVacancyService _vacancyService;

	public VacancyController(IVacancyService vacancyService)
	{
		_vacancyService = vacancyService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll(Guid companyId, [FromQuery] VacancyRequestParameters requestParameters)
	{
		var response = await _vacancyService.GetAllAsync(companyId, requestParameters);

		Response.Headers.Append("Pagination", JsonSerializer.Serialize(response.PagingData));

		return Ok(response);
	}

	[HttpGet("{id:guid}", Name = "GetVacancyById")]
	public async Task<IActionResult> GetById(Guid companyId, Guid id)
	{
		var response = await _vacancyService.GetByIdAsync(companyId, id);

		return Ok(response);
	}

	[HttpGet("{id:guid}/profession")]
	public async Task<IActionResult> GetProfession(Guid companyId, Guid id)
	{
		var response = await _vacancyService.GetProfessionByIdAsync(companyId, id);

		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> Create(Guid companyId, VacancyRequestDto vacancyDto)
	{
		var response = await _vacancyService.CreateAsync(companyId, vacancyDto);

		return CreatedAtRoute("GetVacancyById", new { companyId, id = response.Id }, response);
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Update(Guid companyId, Guid id, VacancyRequestDto vacancyDto)
	{
		await _vacancyService.UpdateAsync(companyId, id, vacancyDto);

		return NoContent();
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> Delete(Guid companyId, Guid id)
	{
		await _vacancyService.DeleteAsync(companyId, id);

		return NoContent();
	}
}
