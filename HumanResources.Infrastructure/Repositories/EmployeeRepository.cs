using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;
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

	public async Task<IEnumerable<Employee>> GetAllAsync(bool trackChanges = false) =>
		trackChanges ?
		await GetAll()
		.ToListAsync() 
		:
		await GetAll()
		.AsNoTracking()
		.ToListAsync();

	public async Task<Employee> GetByIdAsync(Guid Id, bool trackChanges = false) =>
		trackChanges ?
		await GetByPredicate(e => e.Id.Equals(Id))
		.FirstOrDefaultAsync()
		:
		await GetByPredicate(e => e.Id.Equals(Id))
		.AsNoTracking()
		.FirstOrDefaultAsync();
}
