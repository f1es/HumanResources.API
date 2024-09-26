using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;

namespace HumanResources.Infrastructure.Extensions;

public static class ProfessionRepositoryExtensions
{
	public static IQueryable<Profession> Search(this IQueryable<Profession> query, ProfessionRequestParameters requestParameters)
	{
		if (string.IsNullOrWhiteSpace(requestParameters.SearchTerm))
			return query;

		return query.Where(p =>
			p.Name
			.ToLower()
			.Contains(requestParameters.SearchTerm.ToLower()));
	}

	public static IQueryable<Profession> Filter(this IQueryable<Profession> query, ProfessionRequestParameters requestParameters)
	{
		return query.Where(p => p.Salary >= requestParameters.MinSalary && p.Salary <= requestParameters.MaxSalary);
	}
}
