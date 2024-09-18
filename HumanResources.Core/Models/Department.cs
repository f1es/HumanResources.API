namespace HumanResources.Core.Models;

public class Department
{
	public int Id { get; set; }
	public string? Name { get; set; }

	public Guid CompanyID { get; set; }
	public Company? Company { get; set; }

	public ICollection<Worker>? Workers { get; set; }
}
