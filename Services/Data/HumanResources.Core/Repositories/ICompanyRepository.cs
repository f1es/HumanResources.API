using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Core.Repositories;

public interface ICompanyRepository : IBaseRepository<Company>
{
	Task<Company> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Company>> GetAllAsync(CompanyRequestParameters pagingParameters, bool trackChanges = false);
}
