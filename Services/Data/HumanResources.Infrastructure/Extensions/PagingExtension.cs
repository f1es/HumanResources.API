using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Infrastructure.Extensions;

public static class PagingExtension
{
	public static IQueryable<T> Paginate<T>(this IQueryable<T> entities, RequestParameters parameters)
	{
		if (parameters.PageNumber <= 0 || parameters.PageSize <= 0)
			parameters = new RequestParameters();

		return entities
		.Skip((parameters.PageNumber - 1) * parameters.PageSize)
		.Take(parameters.PageSize);
	}
}
