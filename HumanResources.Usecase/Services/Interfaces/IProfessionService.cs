using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;
using HumanResources.Core.Models;

namespace HumanResources.Usecase.Services.Interfaces;

public interface IProfessionService
{
	Task<IEnumerable<ProfessionResponseDto>> GetAllAsync(PagingParameters pagingParameters);
	Task<ProfessionResponseDto> GetByIdAsync(Guid id);
	Task<ProfessionResponseDto> CreateAsync(ProfessionRequestDto professionDto);
	Task UpdateAsync(Guid id, ProfessionRequestDto professionDto);
	Task DeleteAsync(Guid id);
}
