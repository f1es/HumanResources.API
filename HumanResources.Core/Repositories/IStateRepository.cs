using HumanResources.Core.Models;

namespace HumanResources.Core.Repositories;

public interface IStateRepository : IBaseRepository<State>
{
	Task<State> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<State>> GetAllAsync(PagingParameters pagingParameters, bool trackChanges = false);
}
