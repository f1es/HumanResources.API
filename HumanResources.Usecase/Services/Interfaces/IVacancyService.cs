using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;

namespace HumanResources.Usecase.Services.Interfaces;

public interface IVacancyService
{
	Task<IEnumerable<VacancyResponseDto>> GetAllAsync(Guid companyId);
	Task<VacancyResponseDto> GetByIdAsync(Guid companyId, Guid id);
	Task<VacancyResponseDto> CreateAsync(Guid companyId, VacancyRequestDto vacancyDto);
	Task UpdateAsync(Guid companyId, Guid id, VacancyRequestDto vacancyDto);
	Task DeleteAsync(Guid companyId, Guid id);
}
