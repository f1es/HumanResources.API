using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;

namespace HumanResources.Usecase.Services.Interfaces;

public interface ICompanyService
{
	Task<IEnumerable<CompanyResponseDto>> GetAllAsync();
	Task<CompanyResponseDto> GetByIdAsync(Guid id);
	Task<CompanyResponseDto> CreateAsync(CompanyRequestDto companyDto);
	Task UpdateAsync(Guid id, CompanyRequestDto companyDto);
	Task DeleteAsync(Guid id);
}
