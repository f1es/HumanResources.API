using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;

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
		
}
