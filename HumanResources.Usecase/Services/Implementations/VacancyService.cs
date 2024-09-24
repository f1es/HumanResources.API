using AutoMapper;
using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;
using HumanResources.Core.Exceptions;
using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Usecase.Services.Interfaces;

namespace HumanResources.Usecase.Services.Implementations;

public class VacancyService : IVacancyService
{
	private readonly IRepositoryManager _repositoryManager;
	private readonly IMapper _mapper;

	public VacancyService(
		IRepositoryManager repositoryManager, 
		IMapper mapper)
	{
		_repositoryManager = repositoryManager;
		_mapper = mapper;
	}

	public async Task<VacancyResponseDto> CreateAsync(Guid companyId, VacancyRequestDto vacancyDto)
	{
		await CheckIfCompanyExistAsync(companyId);

		var vacancyModel = _mapper.Map<Vacancy>(vacancyDto);
		vacancyModel.Id = Guid.NewGuid();
		vacancyModel.ComapnyId = companyId;

		_repositoryManager.VacancyRepository.Create(vacancyModel);
		await _repositoryManager.SaveAsync();

		var vacancyResponse = _mapper.Map<VacancyResponseDto>(vacancyModel);
		return vacancyResponse;
	}

	public async Task DeleteAsync(Guid companyId, Guid id)
	{
		await CheckIfCompanyExistAsync(companyId);

		var vacancy = await GetByIdAndCheckIfExistAsync(id);
		_repositoryManager.VacancyRepository.Delete(vacancy);
		await _repositoryManager.SaveAsync();
	}

	public async Task<IEnumerable<VacancyResponseDto>> GetAllAsync(Guid companyId)
	{
		await CheckIfCompanyExistAsync(companyId);
		
		var vacancies = await _repositoryManager.VacancyRepository.GetAllAsync();
		var vacanciesResponse = _mapper.Map<IEnumerable<VacancyResponseDto>>(vacancies);
		return vacanciesResponse;
	}

	public async Task<VacancyResponseDto> GetByIdAsync(Guid companyId, Guid id)
	{
		await CheckIfCompanyExistAsync(companyId);
		throw new NotImplementedException();
	}

	public async Task UpdateAsync(Guid companyId, Guid id, VacancyRequestDto vacancyDto)
	{
		await CheckIfCompanyExistAsync(companyId);
		
		var vacancyModel = await GetByIdAndCheckIfExistAsync(id, trackChanges: true);

		vacancyModel = _mapper.Map(vacancyDto, vacancyModel);
		_repositoryManager.VacancyRepository.Update(vacancyModel);

		await _repositoryManager.SaveAsync();
	}

	private async Task CheckIfCompanyExistAsync(Guid companyId)
	{
		var company = await _repositoryManager.CompanyRepository.GetByIdAsync(companyId);

		if (company is null)
			throw new NotFoundException($"Company with id {companyId} not found");
	}
	private async Task<Vacancy> GetByIdAndCheckIfExistAsync(Guid id, bool trackChanges = false)
	{
		var vacancy = await _repositoryManager.VacancyRepository.GetByIdAsync(id, trackChanges);

		if (vacancy is null)
			throw new NotFoundException($"Vacancy with id {id} not found");

		return vacancy;
	}
}
