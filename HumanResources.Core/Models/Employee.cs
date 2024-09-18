namespace HumanResources.Core.Models;

public class Employee
{
	public Guid Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public DateTime Birthday { get; set; }
}
