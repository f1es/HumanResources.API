using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;

namespace HumanResources.Usecase.Services.Interfaces;

public interface ICompanyService
{
	Task<IEnumerable<CompanyResponseDto>> GetAllAsync();
	Task<CompanyResponseDto> GetByIdAsync(Guid Id);
	Task<CompanyResponseDto> CreateAsync(CompanyRequestDto company);
	Task UpdateAsync(Guid Id, CompanyRequestDto company);
	Task RemoveAsync(Guid Id);
}
