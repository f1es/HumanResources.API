using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Infrastructure.Context;
using HumanResources.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Infrastructure.Repositories;

public class WorkerRepository : BaseRepository<Worker>, IWorkerRepository
{
	private readonly HumanResourcesDbContext _context;

	public WorkerRepository(HumanResourcesDbContext context)
		: base(context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Worker>> GetAllAsync(Guid departmentId, WorkerRequestParameters requestParameters, bool trackChanges = false) =>
		await _context.DepartmentWorkers
		.Where(dw => dw.DepartmentId.Equals(departmentId))
		.Select(dw => dw.Worker)
		.Sort(requestParameters)
		.Search(requestParameters)
		.ToListAsync();

	public async Task<Worker> GetByIdAsync(Guid Id, bool trackChanges = false) =>
		await GetByPredicate(w => w.Id.Equals(Id), trackChanges).FirstOrDefaultAsync();
}
