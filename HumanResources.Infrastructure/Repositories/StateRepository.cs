using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Infrastructure.Repositories;

public class StateRepository : BaseRepository<State>, IStateRepository
{
	private readonly HumanResourcesDbContext _context;

	public StateRepository(HumanResourcesDbContext context)
		: base(context)
	{
		_context = context;
	}

	public async Task<IEnumerable<State>> GetAllAsync(PagingParameters pagingParameters, bool trackChanges = false) =>
		await GetAll(trackChanges).ToListAsync();

	public async Task<State> GetByIdAsync(Guid Id, bool trackChanges = false) => 
		await GetByPredicate(s => s.Id.Equals(Id), trackChanges).FirstOrDefaultAsync();
}
