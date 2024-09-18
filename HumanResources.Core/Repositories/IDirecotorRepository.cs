using HumanResources.Core.Models;

namespace HumanResources.Core.Repositories;

public interface IDirecotorRepository : IBaseRepository<Director>
{
	Task<Director> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Director>> GetAllAsync(bool trackChanges = false);
}
