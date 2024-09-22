using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;
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

	public async Task<IEnumerable<Speciality>> GetAllAsync(bool trackChanges = false) => 
		trackChanges ?
		await GetAll()
		.ToListAsync()
		:
		await GetAll() 
		.AsNoTracking()
		.ToListAsync();

	public async Task<Speciality> GetByIdAsync(Guid Id, bool trackChanges = false) => 
		trackChanges ?
		await GetByPredicate(s => s.Id.Equals(Id))
		.FirstOrDefaultAsync()
		:
		await GetByPredicate(s => s.Id.Equals(Id))
		.AsNoTracking()
		.FirstOrDefaultAsync();
}
