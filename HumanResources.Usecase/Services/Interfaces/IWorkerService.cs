﻿using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;

namespace HumanResources.Usecase.Services.Interfaces;

public interface IWorkerService
{
	Task<IEnumerable<WorkerResponseDto>> GetAllAsync(Guid companyId, Guid departmentId);
	Task<WorkerResponseDto> GetByIdAsync(Guid companyId, Guid departmentId, Guid id);
	Task<WorkerResponseDto> CreateAsync(Guid companyId, Guid departmentId, WorkerRequestDto workerDto);
	Task UpdateAsync(Guid companyId, Guid departmentId, Guid id, WorkerRequestDto workerDto);
	Task DeleteAsync(Guid companyId, Guid departmentId, Guid id);
}