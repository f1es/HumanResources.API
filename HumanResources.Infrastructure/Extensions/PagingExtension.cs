using HumanResources.Core.Models;

namespace HumanResources.Infrastructure.Extensions;

public static class PagingExtension
{
	public static IQueryable<T> Paginate<T>(this IQueryable<T> entities, PagingParameters paging)
	{
		if (paging.PageNumber <= 0 || paging.PageSize <= 0)
			paging = new PagingParameters();

		return entities
		.Skip((paging.PageNumber - 1) * paging.PageSize)
		.Take(paging.PageSize);
	}
}
