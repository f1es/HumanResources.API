using System.Linq.Expressions;

namespace HumanResources.Core.Repositories;

public interface IBaseRepository<T> where T : class
{
	void Delete(T entity);
	void Create(T entity);
	void Update(T entity);
}
