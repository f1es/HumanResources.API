using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Extensions;
using System.Linq.Dynamic.Core;

namespace HumanResources.Infrastructure.Extensions;

public static class DepartmentRepositoryExtensions
{
	public static IQueryable<Department> Search(this IQueryable<Department> query, DepartmentRequestParameters requestParameters)
	{
		if (string.IsNullOrWhiteSpace(requestParameters.SearchTerm))
			return query;

		return query
			.Where(d =>
			d.Name
			.ToLower()
			.Contains(requestParameters.SearchTerm.ToLower()));
	}

	public static IQueryable<Department> Sort(this IQueryable<Department> query, DepartmentRequestParameters requestParameters)
	{
		if (string.IsNullOrWhiteSpace(requestParameters.OrederByQuery))
			return query.OrderBy(d => d.Name);

		var sortQuery = SortQueryBuilder.BuildSortQuery<Department>(requestParameters.OrederByQuery);

		if (string.IsNullOrWhiteSpace(sortQuery))
			return query.OrderBy(c => c.Name);

		return query.OrderBy(sortQuery);
	}
}
