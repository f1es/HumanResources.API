using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Core.Repositories;

public interface IProfessionRepository : IBaseRepository<Profession>
{
	Task<Profession> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Profession>> GetAllAsync(RequestParameters pagingParameters, bool trackChanges = false);
}
