namespace HumanResources.Core.Models;

public class State
{
	public Guid Id { get; set; }
	public string? Name { get; set; }

	public ICollection<Worker>? Workers { get; set; }
}
