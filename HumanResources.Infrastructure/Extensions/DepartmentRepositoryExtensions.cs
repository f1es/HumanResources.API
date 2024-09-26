using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;

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
}
