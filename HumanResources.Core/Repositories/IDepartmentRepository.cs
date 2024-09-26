using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Core.Repositories;

public interface IDepartmentRepository : IBaseRepository<Department>
{
	Task<Department> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Department>> GetAllAsync(DepartmentRequestParameters pagingParameters, bool trackChanges = false);
}
