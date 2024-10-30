using HumanResources.Core.Models;
using HumanResources.Core.Repositories;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Infrastructure.Context;
using HumanResources.Infrastructure.Extensions;
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

    public async Task<IEnumerable<Department>> GetAllAsync(Guid companyId, DepartmentRequestParameters requestParameters, bool trackChanges = false) => 
		await GetByPredicate(d => d.CompanyId.Equals(companyId), trackChanges)
		.Sort(requestParameters)
		.Search(requestParameters)
		.Paginate(requestParameters)
		.ToListAsync();

	public async Task<Department> GetByIdAsync(Guid Id, bool trackChanges = false) =>
		await GetByPredicate(d => d.Id.Equals(Id), trackChanges).FirstOrDefaultAsync();
}
