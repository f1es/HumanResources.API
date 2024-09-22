using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;
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

	public async Task<IEnumerable<Worker>> GetAllAsync(bool trackChanges = false) =>
		trackChanges ?
		await GetAll()
		.ToListAsync()
		:
		await GetAll()
		.AsNoTracking()
		.ToListAsync();

	public async Task<Worker> GetByIdAsync(Guid Id, bool trackChanges = false) => 
		trackChanges ?
		await GetByPredicate(w => w.Id.Equals(Id))
		.FirstOrDefaultAsync()
		:
		await GetByPredicate(w => w.Id.Equals(Id))
		.AsNoTracking()
		.FirstOrDefaultAsync();
}
