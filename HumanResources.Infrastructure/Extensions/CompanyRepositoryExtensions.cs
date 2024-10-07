using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Extensions;
using System.Linq.Dynamic.Core;

namespace HumanResources.Infrastructure.Extensions;

public static class CompanyRepositoryExtensions
{
	public static IQueryable<Company> Search(this IQueryable<Company> query, CompanyRequestParameters requestParameters)
	{
		if (string.IsNullOrWhiteSpace(requestParameters.SearchTerm)) 
			return query;

		return query
			.Where(c =>
			c.Name
			.ToLower()
			.Contains(requestParameters.SearchTerm.ToLower()));
	}
	
	public static IQueryable<Company> Sort(this IQueryable<Company> query, CompanyRequestParameters requestParameters)
	{
		if (string.IsNullOrWhiteSpace(requestParameters.OrederByQuery))
			return query.OrderBy(c => c.Name);

		var sortQuery = SortQueryBuilder.BuildSortQuery<Company>(requestParameters.OrederByQuery);

		if (string.IsNullOrWhiteSpace(sortQuery))
			return query.OrderBy(c => c.Name);

		return query.SortByDynamicQuery(sortQuery);
	}
}
