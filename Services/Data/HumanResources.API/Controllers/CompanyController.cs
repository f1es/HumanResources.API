using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Services.Interfaces;
using HumanResources.Usecase.Usecases.Companies.Commands.CreateCompany;
using HumanResources.Usecase.Usecases.Companies.Commands.DeleteCompany;
using HumanResources.Usecase.Usecases.Companies.Commands.UpdateCompany;
using HumanResources.Usecase.Usecases.Companies.Queries.GetComapny;
using HumanResources.Usecase.Usecases.Companies.Queries.GetCompanies;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace HumanResources.API.Controllers;

//[Authorize]
[ApiController]
[Route("api/companies")]
public class CompanyController : ControllerBase
{
	private readonly ICompanyService _companyService;
	private readonly IMediator _mediator;
	private readonly IWebLogger _webLogger;

	public CompanyController(
		ICompanyService companyService, 
		IMediator mediator,
		IWebLogger webLogger)
	{
		_companyService = companyService;
		_mediator = mediator;
		_webLogger = webLogger;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] CompanyRequestParameters requestParameters)
	{
		var query = new GetCompaniesQuery(requestParameters);
		var response = await _mediator.Send(query);

		Response.Headers.Append("Pagination", JsonSerializer.Serialize(response.Companies.PagingData));
		await _webLogger.LogInfoAsync("call api/companies GET", Response.StatusCode, User.Claims);

		return Ok(response);
	}

	[HttpGet("{id:guid}", Name = "GetCompanyById")]
	public async Task<IActionResult> GetById(Guid id)
	{
		var query = new GetCompanyQuery(id);
		var response = await _mediator.Send(query);

		await _webLogger.LogInfoAsync($"call api/companies/{id} GET", Response.StatusCode, User.Claims);

		return Ok(response);
	}

	[HttpPost]
	public async Task<IActionResult> Create(CreateCompanyCommand command)
	{
		var response = await _mediator.Send(command);

		await _webLogger.LogInfoAsync("call api/companies POST", Response.StatusCode, User.Claims);

		return Ok(response);
	}

	[HttpDelete("{id:guid}")]
	public async Task<IActionResult> Delete(Guid id)
	{
		var command = new DeleteCompanyCommand(id);
		await _mediator.Send(command);

		await _webLogger.LogInfoAsync($"call api/companies/{id} DELETE", Response.StatusCode, User.Claims);

		return NoContent();
	}

	[HttpPut("{id:guid}")]
	public async Task<IActionResult> Update(Guid id, CompanyUpdateModel company)
	{
		var command = new UpdateCompanyCommand(id, company);
		await _mediator.Send(command);

		await _webLogger.LogInfoAsync($"call api/companies/{id} PUT", Response.StatusCode, User.Claims);

		return NoContent();
	}
}
