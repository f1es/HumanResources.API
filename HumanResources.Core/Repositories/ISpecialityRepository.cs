using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Core.Repositories;

public interface ISpecialityRepository : IBaseRepository<Speciality>
{
	Task<Speciality> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Speciality>> GetAllAsync(RequestParameters pagingParameters, bool trackChanges = false);
}
