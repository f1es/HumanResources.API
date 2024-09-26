using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;

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
}
