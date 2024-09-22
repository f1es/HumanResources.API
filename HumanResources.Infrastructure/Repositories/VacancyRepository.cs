using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Infrastructure.Repositories;

public class VacancyRepository : BaseRepository<Vacancy>, IVacancyRepository
{
	private readonly HumanResourcesDbContext _context;

	public VacancyRepository(HumanResourcesDbContext context)
		: base(context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Vacancy>> GetAllAsync(bool trackChanges = false) => 
		trackChanges ?
		await GetAll()
		.ToListAsync()
		:
		await GetAll()
		.AsNoTracking()
		.ToListAsync();

	public async Task<Vacancy> GetByIdAsync(Guid Id, bool trackChanges = false) => 
		trackChanges ?
		await GetByPredicate(v => v.Id.Equals(Id))
		.FirstOrDefaultAsync()
		:
		await GetByPredicate(v => v.Id.Equals(Id))
		.AsNoTracking()
		.FirstOrDefaultAsync();
}
