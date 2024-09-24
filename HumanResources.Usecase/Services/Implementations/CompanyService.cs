using AutoMapper;
using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;
using HumanResources.Core.Exceptions;
using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Usecase.Services.Interfaces;

namespace HumanResources.Usecase.Services.Implementations;

public class CompanyService : ICompanyService
{
	private readonly IRepositoryManager _repositoryManager;
	private readonly IMapper _mapper;

	public CompanyService(
		IRepositoryManager repositoryManager, 
		IMapper mapper)
	{
		_repositoryManager = repositoryManager;
		_mapper = mapper;
	}

	public async Task<CompanyResponseDto> CreateAsync(CompanyRequestDto companyDto)
	{
		var companyModel = _mapper.Map<Company>(companyDto);
		companyModel.Id = Guid.NewGuid();

		_repositoryManager.CompanyRepository.Create(companyModel);
		await _repositoryManager.SaveAsync();

		var companyResponse = _mapper.Map<CompanyResponseDto>(companyModel);
		return companyResponse;
	}

	public async Task<IEnumerable<CompanyResponseDto>> GetAllAsync()
	{
		var companies = await _repositoryManager.CompanyRepository.GetAllAsync();
		var companiesResponse = _mapper.Map<IEnumerable<CompanyResponseDto>>(companies);
		return companiesResponse;
	}

	public async Task<CompanyResponseDto> GetByIdAsync(Guid id)
	{
		var companyModel = await GetByIdAndCheckIfExist(id);
		var companyResponse = _mapper.Map<CompanyResponseDto>(companyModel);
		return companyResponse;
	}

	public async Task DeleteAsync(Guid id)
	{
		var company = await GetByIdAndCheckIfExist(id);
		_repositoryManager.CompanyRepository.Delete(company);
		await _repositoryManager.SaveAsync();
	}

	public async Task UpdateAsync(Guid id, CompanyRequestDto companyDto)
	{
		var companyModel = await GetByIdAndCheckIfExist(id, trackChanges: true);

		companyModel = _mapper.Map(companyDto, companyModel);
		_repositoryManager.CompanyRepository.Update(companyModel);

		await _repositoryManager.SaveAsync();
	}

	private async Task<Company> GetByIdAndCheckIfExist(Guid id, bool trackChanges = false)
	{
		var company = await _repositoryManager.CompanyRepository.GetByIdAsync(id, trackChanges);

		if (company is null)
			throw new NotFoundException($"Company with id {id} not found");

		return company;
	}
}
