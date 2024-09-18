using HumanResources.Core.Models;

namespace HumanResources.Core.Repositories;

public interface ICompanyRepository : IBaseRepository<Company>
{
	Task<Company> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Company>> GetAllAsync(bool trackChanges = false);
}
