using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Infrastructure.Context;
using HumanResources.Infrastructure.Extensions;
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

	public async Task<IEnumerable<Vacancy>> GetAllAsync(Guid companyId, VacancyRequestParameters requestParameters, bool trackChanges = false) =>
		await GetByPredicate(v => v.ComapnyId.Equals(companyId), trackChanges)
		.Sort(requestParameters)
		.Search(requestParameters)
		.ToListAsync();

	public async Task<Vacancy> GetByIdAsync(Guid Id, bool trackChanges = false) =>
		await GetByPredicate(v => v.Id.Equals(Id), trackChanges).FirstOrDefaultAsync();
}
