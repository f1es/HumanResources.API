using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Infrastructure.Repositories;

public class ProfessionRepository : BaseRepository<Profession>, IProfessionRepository
{
	private readonly HumanResourcesDbContext _context;

	public ProfessionRepository(HumanResourcesDbContext context)
		: base(context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Profession>> GetAllAsync(bool trackChanges = false) => 
		trackChanges ?
		await GetAll()
		.ToListAsync()
		:
		await GetAll()
		.AsNoTracking()
		.ToListAsync();

	public async Task<Profession> GetByIdAsync(Guid Id, bool trackChanges = false) => 
		trackChanges ?
		await GetByPredicate(p => p.Id.Equals(Id)) 
		.FirstOrDefaultAsync()
		:
		await GetByPredicate(p => p.Id.Equals(Id))
		.AsNoTracking()
		.FirstOrDefaultAsync();
}
