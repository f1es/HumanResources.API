using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;
using HumanResources.Core.Shared.Features;
using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Usecase.Services.Interfaces;

public interface ICompanyService
{
	Task<PagedList<CompanyResponseDto>> GetAllAsync(CompanyRequestParameters requestParameters);
	Task<CompanyResponseDto> GetByIdAsync(Guid id);
	Task<CompanyResponseDto> CreateAsync(CompanyRequestDto companyDto);
	Task UpdateAsync(Guid id, CompanyRequestDto companyDto);
	Task DeleteAsync(Guid id);
}
