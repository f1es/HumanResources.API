using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Infrastructure.Repositories;

public class DirectorRepository : BaseRepository<Director>, IDirectorRepository
{
	private readonly HumanResourcesDbContext _context;
	public DirectorRepository(HumanResourcesDbContext context)
		: base(context)
	{
		_context = context;
	}
	public async Task<IEnumerable<Director>> GetAllAsync(bool trackChanges = false) => 
		trackChanges ?
		await GetAll()
		.ToListAsync() 
		:
		await GetAll()
		.AsNoTracking()
		.ToListAsync();

	public async Task<Director> GetByIdAsync(Guid Id, bool trackChanges = false) => 
		trackChanges ?
		await GetByPredicate(d => d.Id.Equals(Id))
		.FirstOrDefaultAsync()
		:
		await GetByPredicate(d => !d.Id.Equals(Id))
		.AsNoTracking()
		.FirstOrDefaultAsync();
}
