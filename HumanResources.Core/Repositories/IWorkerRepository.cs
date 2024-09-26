using HumanResources.Core.Models;

namespace HumanResources.Core.Repositories;

public interface IWorkerRepository : IBaseRepository<Worker>
{
	Task<Worker> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Worker>> GetAllAsync(PagingParameters pagingParameters, bool trackChanges = false);
}
