using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Infrastructure.Context;
using HumanResources.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Infrastructure.Repositories;

public class SpecialityRepository : BaseRepository<Speciality>, ISpecialityRepository
{
	private readonly HumanResourcesDbContext _context;

	public SpecialityRepository(HumanResourcesDbContext context) 
		: base(context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Speciality>> GetAllAsync(RequestParameters pagingParameters, bool trackChanges = false) =>
		await GetAll()
		.Paginate(pagingParameters)
		.ToListAsync();

	public async Task<Speciality> GetByIdAsync(Guid Id, bool trackChanges = false) =>
		await GetByPredicate(s => s.Id.Equals(Id)).FirstOrDefaultAsync();
}
