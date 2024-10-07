using HumanResources.Usecase.Extensions;
using System.Linq.Dynamic.Core;

namespace HumanResources.Infrastructure.Extensions;

public static class SortExtension
{
	public static IQueryable<T> SortByDynamicQuery<T>(this IQueryable<T> values, string sortQuery) //Prop asc, Prop desc
	{
		var query = SortQueryBuilder.BuildSortQuery<T>(sortQuery);
		return values.OrderBy(query);
	}
}
