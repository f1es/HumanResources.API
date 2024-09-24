using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;

namespace HumanResources.Usecase.Services.Interfaces;

public interface IProfessionService
{
	Task<IEnumerable<ProfessionResponseDto>> GetAllAsync();
	Task<ProfessionResponseDto> GetByIdAsync(Guid id);
	Task<ProfessionResponseDto> CreateAsync(ProfessionRequestDto professionDto);
	Task UpdateAsync(Guid id, ProfessionRequestDto professionDto);
	Task DeleteAsync(Guid id);
}
