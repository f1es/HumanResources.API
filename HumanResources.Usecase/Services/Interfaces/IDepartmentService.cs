using HumanResources.Core.Models;
using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;

namespace HumanResources.Usecase.Services.Interfaces;

public interface IDepartmentService
{
	Task<IEnumerable<DepartmentResponseDto>> GetAllAsync(Guid companyId, RequestParameters requestParameters);
	Task<DepartmentResponseDto> GetByIdAsync(Guid companyId, Guid id);
	Task<DepartmentResponseDto> CreateAsync(Guid companyId, DepartmentRequestDto departmentDto);
	Task UpdateAsync(Guid companyId, Guid id, DepartmentRequestDto departmentDto);
	Task DeleteAsync(Guid companyId, Guid id);
}
