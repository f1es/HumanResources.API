﻿using AutoMapper;
using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;
using HumanResources.Core.Exceptions;
using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Usecase.Services.Interfaces;

namespace HumanResources.Usecase.Services.Implementations;

public class DepartmentService : IDepartmentService
{
	private readonly IRepositoryManager _repositoryManager;
	private readonly IMapper _mapper;

	public DepartmentService(
		IRepositoryManager repositoryManager, 
		IMapper mapper)
	{
		_repositoryManager = repositoryManager;
		_mapper = mapper;
	}

	public async Task<DepartmentResponseDto> CreateAsync(Guid companyId, DepartmentRequestDto departmentDto)
	{
		await CheckIfCompanyExist(companyId);
		var departmentModel = _mapper.Map<Department>(departmentDto);
		departmentModel.CompanyId = companyId;

		_repositoryManager.DepartmentRepository.Create(departmentModel);
		await _repositoryManager.SaveAsync();

		var departmentResponse = _mapper.Map<DepartmentResponseDto>(departmentModel);
		return departmentResponse;
	}

	public async Task DeleteAsync(Guid companyId, Guid id)
	{
		await CheckIfCompanyExist(companyId);

		var department = await GetDepartmentByIdAndCheckIfExist(id);
		_repositoryManager.DepartmentRepository.Delete(department);
		await _repositoryManager.SaveAsync();
	}

	public async Task<IEnumerable<DepartmentResponseDto>> GetAllAsync(Guid companyId)
	{
		await CheckIfCompanyExist(companyId);

		var departments = await _repositoryManager.DepartmentRepository.GetAllAsync();
		var depaetmentsResponse = _mapper.Map<IEnumerable<DepartmentResponseDto>>(departments);
		return depaetmentsResponse;
	}

	public async Task<DepartmentResponseDto> GetByIdAsync(Guid companyId, Guid id)
	{
		await CheckIfCompanyExist(companyId);
		var departmentModel = await GetDepartmentByIdAndCheckIfExist(id);
		var departmentResponse = _mapper.Map<DepartmentResponseDto>(departmentModel);
		return departmentResponse;
	}

	public async Task UpdateAsync(Guid companyId, Guid id, DepartmentRequestDto departmentDto)
	{
		await CheckIfCompanyExist(companyId);

		var departmentModel = await GetDepartmentByIdAndCheckIfExist(id, trackChanges: true);

		departmentModel = _mapper.Map(departmentDto, departmentModel);
		_repositoryManager.DepartmentRepository.Update(departmentModel);

		await _repositoryManager.SaveAsync();
	}

	private async Task CheckIfCompanyExist(Guid companyId)
	{
		var company = await _repositoryManager.CompanyRepository.GetByIdAsync(companyId);

		if (company is null)
			throw new NotFoundException($"Company with id {companyId} not found");
	}

	private async Task<Department> GetDepartmentByIdAndCheckIfExist(Guid departmentId, bool trackChanges = false)
	{
		var department = await _repositoryManager.DepartmentRepository.GetByIdAsync(departmentId, trackChanges);

		if (department is null)
			throw new NotFoundException($"Department with id {departmentId} not found");

		return department;
	}
}