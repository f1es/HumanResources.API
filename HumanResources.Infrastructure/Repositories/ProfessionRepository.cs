using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Infrastructure.Context;
using HumanResources.Infrastructure.Extensions;
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

	public async Task<IEnumerable<Profession>> GetAllAsync(ProfessionRequestParameters requestParameters, bool trackChanges = false) => 
		await GetAll(trackChanges)
		.Search(requestParameters)
		.Filter(requestParameters)
		.Paginate(requestParameters)
		.ToListAsync();

	public async Task<Profession> GetByIdAsync(Guid Id, bool trackChanges = false) =>
		await GetByPredicate(p => p.Id.Equals(Id), trackChanges).FirstOrDefaultAsync();
}
