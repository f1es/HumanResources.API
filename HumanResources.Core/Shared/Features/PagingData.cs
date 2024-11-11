namespace HumanResources.Core.Shared.Features;

public class PagingData
{
	public int CurrentPage { get; set; }
	public int PageCount { get; set; }
	public int PageSize { get; set; }
	public int Count { get; set; }

	public bool HasNext => CurrentPage > 1;
	public bool HasPrevious => CurrentPage < PageCount;
}
