using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Extensions;

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

	public static IQueryable<Department> Sort(this IQueryable<Department> query, CompanyRequestParameters requestParameters)
	{
		if (string.IsNullOrWhiteSpace(requestParameters.OrederByQuery))
			return query.OrderBy(d => d.Name);

		var sortQuery = SortQueryBuilder.BuildSortQuery<Company>(requestParameters.OrederByQuery);

		if (string.IsNullOrWhiteSpace(sortQuery))
			return query.OrderBy(c => c.Name);

		return query.SortByDynamicQuery(sortQuery);
	}
}
