using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Core.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
	Task<Employee> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Employee>> GetAllAsync(RequestParameters pagingParameters, bool trackChanges = false);
}
