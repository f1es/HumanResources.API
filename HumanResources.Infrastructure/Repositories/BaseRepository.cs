using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HumanResources.Infrastructure.Repositories;

public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
{
	private readonly HumanResourcesDbContext _context;

    public BaseRepository(HumanResourcesDbContext context)
    {
        _context = context;
    }

    protected IQueryable<T> GetByPredicate(Expression<Func<T, bool>> predicate, bool trackChanges = false) =>
        trackChanges ?
        _context.Set<T>()
        .Where(predicate)
        :
		_context.Set<T>()
		.Where(predicate)
        .AsNoTracking();

    protected IQueryable<T> GetAll(bool trackChanges = false) =>
		trackChanges ? 
        _context.Set<T>()
        :
		_context.Set<T>()
        .AsNoTracking();

    public void Delete(T entity) => 
        _context.Set<T>()
        .Remove(entity);

    public void Create(T entity) => 
        _context.Set<T>()
        .Add(entity);

    public void Update(T entity) => 
        _context.Set<T>()
        .Update(entity);
}
