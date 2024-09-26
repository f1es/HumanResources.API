namespace HumanResources.Core.Models;

public record PagingParameters(
	int PageNumber = 1,
	int PageSize = 10);
