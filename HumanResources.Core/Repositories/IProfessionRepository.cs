using HumanResources.Core.Models;

namespace HumanResources.Core.Repositories;

public interface IProfessionRepository : IBaseRepository<Profession>
{
	Task<Profession> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Profession>> GetAllAsync(PagingParameters pagingParameters, bool trackChanges = false);
}
