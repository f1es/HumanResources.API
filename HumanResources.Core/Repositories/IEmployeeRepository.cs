using HumanResources.Core.Models;

namespace HumanResources.Core.Repositories;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
	Task<Employee> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Employee>> GetAllAsync(bool trackChanges = false);
}
