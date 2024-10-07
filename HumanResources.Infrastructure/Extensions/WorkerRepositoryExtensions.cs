using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Extensions;

namespace HumanResources.Infrastructure.Extensions;

public static class WorkerRepositoryExtensions
{
	public static IQueryable<Worker> Search(this IQueryable<Worker> query, WorkerRequestParameters requestParameters)
	{
		if (string.IsNullOrWhiteSpace(requestParameters.SearchTerm))
			return query;

		return query
			.Where(w => string.Join(' ', w.FirstName, w.LastName, w.Phone)
			.ToLower()
			.Contains(requestParameters.SearchTerm.ToLower()));
	}

	public static IQueryable<Worker> Sort(this IQueryable<Worker> query, CompanyRequestParameters requestParameters)
	{
		if (string.IsNullOrWhiteSpace(requestParameters.OrederByQuery))
			return query.OrderBy(w => w.FirstName);

		var sortQuery = SortQueryBuilder.BuildSortQuery<Company>(requestParameters.OrederByQuery);

		if (string.IsNullOrWhiteSpace(sortQuery))
			return query.OrderBy(w => w.FirstName);

		return query.SortByDynamicQuery(sortQuery);
	}
}
