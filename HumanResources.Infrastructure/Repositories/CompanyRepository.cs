using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Infrastructure.Context;
using HumanResources.Infrastructure.Extensions;
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
        await GetByPredicate(c => c.Id.Equals(Id), trackChanges).FirstOrDefaultAsync();

    public async Task<IEnumerable<Company>> GetAllAsync(RequestParameters pagingParameters, bool trackChanges = false) =>
        await GetAll(trackChanges)
        .Paginate(pagingParameters)
        .ToListAsync();
}
