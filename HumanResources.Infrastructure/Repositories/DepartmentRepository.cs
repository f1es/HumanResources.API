using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Infrastructure.Repositories;

public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
{
	private readonly HumanResourcesDbContext _context;
    public DepartmentRepository(HumanResourcesDbContext context)
		: base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Department>> GetAllAsync(bool trackChanges = false) => 
		trackChanges ?
		await GetAll()
		.ToListAsync() 
		:
		await GetAll()
		.AsNoTracking()
		.ToListAsync();

	public async Task<Department> GetByIdAsync(Guid Id, bool trackChanges = false) =>
		trackChanges ?
		await GetByPredicate(d => d.Id.Equals(Id))
		.FirstOrDefaultAsync()
		:
		await GetByPredicate(d => d.Id.Equals(Id))
		.AsNoTracking()
		.FirstOrDefaultAsync();
}
