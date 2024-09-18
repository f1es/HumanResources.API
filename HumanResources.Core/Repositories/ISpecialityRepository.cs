using HumanResources.Core.Models;

namespace HumanResources.Core.Repositories;

public interface ISpecialityRepository : IBaseRepository<Speciality>
{
	Task<Speciality> GetByIdAsync(Guid Id, bool trackChanges = false);
	Task<IEnumerable<Speciality>> GetAllAsync(bool trackChanges = false);
}
