using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Core.Repositories;

public interface IWorkerRepository : IBaseRepository<Worker>
{
	Task<Worker> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Worker>> GetAllAsync(RequestParameters pagingParameters, bool trackChanges = false);
}
