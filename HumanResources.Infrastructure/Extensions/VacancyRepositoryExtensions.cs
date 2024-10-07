using HumanResources.Core.Models;
using HumanResources.Core.Shared.Parameters;
using HumanResources.Usecase.Extensions;
using System.Linq.Dynamic.Core;

namespace HumanResources.Infrastructure.Extensions;

public static class VacancyRepositoryExtensions
{
	public static IQueryable<Vacancy> Sort(this IQueryable<Vacancy> query, VacancyRequestParameters requestParameters)
	{
		if (string.IsNullOrWhiteSpace(requestParameters.OrederByQuery))
			return query.OrderBy(v => v.ReceiptDate);

		var sortQuery = SortQueryBuilder.BuildSortQuery<Vacancy>(requestParameters.OrederByQuery);

		if (string.IsNullOrWhiteSpace(sortQuery))
			return query.OrderBy(v => v.ReceiptDate);

		return query.OrderBy(sortQuery);
	}
}
