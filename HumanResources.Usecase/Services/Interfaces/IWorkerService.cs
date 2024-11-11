using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;
using HumanResources.Core.Shared.Features;
using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Usecase.Services.Interfaces;

public interface IWorkerService
{
	Task<PagedList<WorkerResponseDto>> GetAllAsync(Guid companyId, Guid departmentId, WorkerRequestParameters requestParameters);
	Task<WorkerResponseDto> GetByIdAsync(Guid companyId, Guid departmentId, Guid id);
	Task<WorkerResponseDto> CreateAsync(Guid companyId, Guid departmentId, WorkerRequestDto workerDto);
	Task UpdateAsync(Guid companyId, Guid departmentId, Guid id, WorkerRequestDto workerDto);
	Task DeleteAsync(Guid companyId, Guid departmentId, Guid id);
}
