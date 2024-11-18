using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Extensions;
using System.Linq.Dynamic.Core;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

	public static IEnumerable<Worker> Search(this IEnumerable<Worker> collection, WorkerRequestParameters requestParameters)
	{
		if (string.IsNullOrWhiteSpace(requestParameters.SearchTerm))
			return collection;

		return collection
			.Where(w => string.Join(' ', w.FirstName, w.LastName, w.Phone)
			.ToLower()
			.Contains(requestParameters.SearchTerm.ToLower()));
	}

	public static IQueryable<Worker> Sort(this IQueryable<Worker> query, WorkerRequestParameters requestParameters)
	{
		if (string.IsNullOrWhiteSpace(requestParameters.OrederByQuery))
			return query.OrderBy(w => w.FirstName);

		var sortQuery = SortQueryBuilder.BuildSortQuery<Worker>(requestParameters.OrederByQuery);

		if (string.IsNullOrWhiteSpace(sortQuery))
			return query.OrderBy(w => w.FirstName);

		return query.OrderBy(sortQuery);
	}

}
