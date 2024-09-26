using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;
using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Usecase.Services.Interfaces;

public interface IProfessionService
{
	Task<IEnumerable<ProfessionResponseDto>> GetAllAsync(ProfessionRequestParameters requestParameters);
	Task<ProfessionResponseDto> GetByIdAsync(Guid id);
	Task<ProfessionResponseDto> CreateAsync(ProfessionRequestDto professionDto);
	Task UpdateAsync(Guid id, ProfessionRequestDto professionDto);
	Task DeleteAsync(Guid id);
}
