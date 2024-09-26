using HumanResources.Core.Models;

namespace HumanResources.Core.Repositories;

public interface IDepartmentRepository : IBaseRepository<Department>
{
	Task<Department> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Department>> GetAllAsync(PagingParameters pagingParameters, bool trackChanges = false);
}
