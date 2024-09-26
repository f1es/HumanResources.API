using AutoMapper;
using HumanResources.Core.Exceptions;
using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Services.Interfaces;

namespace HumanResources.Usecase.Services.Implementations;

public class WorkerService : IWorkerService
{
	private readonly IRepositoryManager _repositoryManager;
	private readonly IMapper _mapper;

	public WorkerService(
		IRepositoryManager repositoryManager,
		IMapper mapper)
	{
		_repositoryManager = repositoryManager;
		_mapper = mapper;
	}

	public async Task<WorkerResponseDto> CreateAsync(Guid companyId, Guid departmentId, WorkerRequestDto workerDto)
	{
		await CheckIfCompanyExistAsync(companyId);
		await CheckIfDepartmentExistAsync(departmentId);

		var workerModel = _mapper.Map<Worker>(workerDto);
		_repositoryManager.WorkerRepository.Create(workerModel);
		await _repositoryManager.SaveAsync();

		var workerResponse = _mapper.Map<WorkerResponseDto>(workerModel);
		return workerResponse;
	}

	public async Task DeleteAsync(Guid companyId, Guid departmentId, Guid id)
	{
		await CheckIfCompanyExistAsync(companyId);
		await CheckIfDepartmentExistAsync(departmentId);

		var worker = await GetWorkerByIdAndCheckIfExistAsync(id);

		_repositoryManager.WorkerRepository.Delete(worker);
		await _repositoryManager.SaveAsync();
	}

	public async Task<IEnumerable<WorkerResponseDto>> GetAllAsync(Guid companyId, Guid departmentId, RequestParameters requestParameters)
	{
		await CheckIfCompanyExistAsync(companyId);
		await CheckIfDepartmentExistAsync(departmentId);

		var workers = await _repositoryManager.WorkerRepository.GetAllAsync(requestParameters);
		var workersResponse = _mapper.Map<IEnumerable<WorkerResponseDto>>(workers);

		return workersResponse;
	}

	public async Task<WorkerResponseDto> GetByIdAsync(Guid companyId, Guid departmentId, Guid id)
	{
		await CheckIfCompanyExistAsync(companyId);
		await CheckIfDepartmentExistAsync(departmentId);

		var worker = await GetWorkerByIdAndCheckIfExistAsync(id);
		var workerResponse = _mapper.Map<WorkerResponseDto>(worker);
		return workerResponse;
	}

	public async Task UpdateAsync(Guid companyId, Guid departmentId, Guid id, WorkerRequestDto workerDto)
	{
		await CheckIfCompanyExistAsync(companyId);
		await CheckIfDepartmentExistAsync(departmentId);

		var worker = await GetWorkerByIdAndCheckIfExistAsync(id);

		worker = _mapper.Map(workerDto, worker);

		await _repositoryManager.SaveAsync();
	}

	private async Task<Worker> GetWorkerByIdAndCheckIfExistAsync(Guid id, bool trackChanges = false)
	{
		var worker = await _repositoryManager.WorkerRepository.GetByIdAsync(id, trackChanges);

		if (worker is null) 
			throw new NotFoundException($"Worker with id {id} not found");

		return worker;
	}

	private async Task CheckIfCompanyExistAsync(Guid companyId)
	{
		var company = await _repositoryManager.CompanyRepository.GetByIdAsync(companyId);

		if (company is null)
			throw new NotFoundException($"Company with id {companyId} not found");
	}

	private async Task CheckIfDepartmentExistAsync(Guid departmentId)
	{
		var department = await _repositoryManager.DepartmentRepository.GetByIdAsync(departmentId);

		if (department is null)
			throw new NotFoundException($"Department with id {departmentId} not found");
	}
}
