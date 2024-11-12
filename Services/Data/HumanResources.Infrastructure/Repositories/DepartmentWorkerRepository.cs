using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;

namespace HumanResources.Infrastructure.Repositories;

public class DepartmentWorkerRepository : BaseRepository<DepartmentWorkers>, IDepartmentWorkerRepository
{
	private HumanResourcesDbContext _context;
	public DepartmentWorkerRepository(HumanResourcesDbContext context) 
		: base(context)
	{
		_context = context;
	}
}
