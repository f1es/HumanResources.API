using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.Infrastructure.Repositories;

public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
{
	private readonly HumanResourcesDbContext _context;
    public CompanyRepository(HumanResourcesDbContext context)
        : base(context)
    {
        _context = context;
    }
    public async Task<Company> GetByIdAsync(Guid Id, bool trackChanges = false) =>
        trackChanges ?
		await GetByPredicate(c => c.Id.Equals(Id))
        .FirstOrDefaultAsync()
        :
		await GetByPredicate(c => c.Id.Equals(Id))
        .AsNoTracking()
		.FirstOrDefaultAsync();

    public async Task<IEnumerable<Company>> GetAllAsync(bool trackChanges = false) => 
        trackChanges ? 
        await GetAll()
        .ToListAsync()
        :
        await GetAll()
        .AsNoTracking()
        .ToListAsync();
}
