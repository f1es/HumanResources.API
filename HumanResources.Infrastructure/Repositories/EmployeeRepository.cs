using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;
using HumanResources.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Infrastructure.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
	private readonly HumanResourcesDbContext _context;

	public EmployeeRepository(HumanResourcesDbContext context)
		: base(context)
	{
		_context = context;
	}

	public async Task<IEnumerable<Employee>> GetAllAsync(PagingParameters pagingParameters, bool trackChanges = false) =>
		await GetAll(trackChanges)
		.Paginate(pagingParameters)
		.ToListAsync();

	public async Task<Employee> GetByIdAsync(Guid Id, bool trackChanges = false) =>
		await GetByPredicate(c => c.Id.Equals(Id), trackChanges).FirstOrDefaultAsync();
}
