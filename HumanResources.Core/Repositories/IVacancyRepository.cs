using HumanResources.Core.Models;

namespace HumanResources.Core.Repositories;

public interface IVacancyRepository : IBaseRepository<Vacancy>
{
	Task<Vacancy> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Vacancy>> GetAllAsync(PagingParameters pagingParameters, bool trackChanges = false);
}
