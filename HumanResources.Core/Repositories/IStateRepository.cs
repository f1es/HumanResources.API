using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Core.Repositories;

public interface IStateRepository : IBaseRepository<State>
{
	Task<State> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<State>> GetAllAsync(RequestParameters pagingParameters, bool trackChanges = false);
}
