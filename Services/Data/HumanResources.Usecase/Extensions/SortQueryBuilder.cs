﻿using System.Reflection;
using System.Text;

namespace HumanResources.Usecase.Extensions;

public static class SortQueryBuilder
{
    public static string BuildSortQuery<T>(string queryString)
    {
        var orderParams = queryString.Split(',');
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var queryBuilder = new StringBuilder();

        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;

            var propertyName = param.Split(' ')[0];
            var propertyInfo = properties.FirstOrDefault(p => p.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase));

            if (propertyInfo is null)
                continue;

            var orderDirection = param.EndsWith("desc") ?
                "descending"
                :
                "ascending";

            queryBuilder.Append($"{propertyInfo.Name} {orderDirection},");
        }

        var orderQuery = queryBuilder.ToString().TrimEnd(',', ' ');

        return orderQuery;
    }
}
