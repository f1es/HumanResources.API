namespace HumanResources.Core.Models;

public class Director
{
	public Guid Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public DateTime Birthday { get; set; }


	public Guid CompanyId { get; set; }
	public Company? Company { get; set; }
}
