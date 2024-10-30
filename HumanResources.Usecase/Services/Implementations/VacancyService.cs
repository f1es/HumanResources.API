using AutoMapper;
using HumanResources.Core.Exceptions;
using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;
using HumanResources.Core.Shared.Parameters;
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

		await GetProfessionByIdAndCheckIfExistAsync(vacancyDto.ProffesionId);

		_repositoryManager.VacancyRepository.Create(vacancyModel);
		await _repositoryManager.SaveAsync();

		var vacancyResponse = _mapper.Map<VacancyResponseDto>(vacancyModel);
		return vacancyResponse;
	}

	public async Task DeleteAsync(Guid companyId, Guid id)
	{
		await CheckIfCompanyExistAsync(companyId);

		var vacancy = await GetVacancyByIdAndCheckIfExistAsync(id);
		_repositoryManager.VacancyRepository.Delete(vacancy);
		await _repositoryManager.SaveAsync();
	}

	public async Task<IEnumerable<VacancyResponseDto>> GetAllAsync(Guid companyId, VacancyRequestParameters requestParameters)
	{
		await CheckIfCompanyExistAsync(companyId);
		
		var vacancies = await _repositoryManager.VacancyRepository.GetAllAsync(companyId, requestParameters);
		var vacanciesResponse = _mapper.Map<IEnumerable<VacancyResponseDto>>(vacancies);
		return vacanciesResponse;
	}

	public async Task<VacancyResponseDto> GetByIdAsync(Guid companyId, Guid id)
	{
		await CheckIfCompanyExistAsync(companyId);
		var vacancyModel = await GetVacancyByIdAndCheckIfExistAsync(id);
		var vacancyResponse = _mapper.Map<VacancyResponseDto>(vacancyModel);
		return vacancyResponse;
	}

	public async Task<ProfessionResponseDto> GetProfessionByIdAsync(Guid companyId, Guid id)
	{
		await CheckIfCompanyExistAsync(companyId);

		var vacancyModel = await GetVacancyByIdAndCheckIfExistAsync(id);
		var professionModel = await GetProfessionByIdAndCheckIfExistAsync(vacancyModel.ProfessionId);

		var professionResponse = _mapper.Map<ProfessionResponseDto>(professionModel);
		return professionResponse;
	}

	public async Task UpdateAsync(Guid companyId, Guid id, VacancyRequestDto vacancyDto)
	{
		await CheckIfCompanyExistAsync(companyId);
		
		var vacancyModel = await GetVacancyByIdAndCheckIfExistAsync(id, trackChanges: true);

		await GetProfessionByIdAndCheckIfExistAsync(vacancyDto.ProffesionId);

		vacancyModel = _mapper.Map(vacancyDto, vacancyModel);

		await _repositoryManager.SaveAsync();
	}

	private async Task CheckIfCompanyExistAsync(Guid companyId)
	{
		var company = await _repositoryManager.CompanyRepository.GetByIdAsync(companyId);

		if (company is null)
			throw new NotFoundException($"Company with id {companyId} not found");
	}

	private async Task<Vacancy> GetVacancyByIdAndCheckIfExistAsync(Guid id, bool trackChanges = false)
	{
		var vacancy = await _repositoryManager.VacancyRepository.GetByIdAsync(id, trackChanges);

		if (vacancy is null)
			throw new NotFoundException($"Vacancy with id {id} not found");

		return vacancy;
	}

	private async Task<Profession> GetProfessionByIdAndCheckIfExistAsync(Guid id, bool trackChanges = false)
	{
		var profession = await _repositoryManager.ProfessionRepository.GetByIdAsync(id, trackChanges);

		if (profession is null)
			throw new NotFoundException($"Profession with id {id} not found");

		return profession;
	}
}
