namespace HumanResources.Core.Models;

public class Department
{
	public Guid Id { get; set; }
	public string? Name { get; set; }

	public Guid CompanyId { get; set; }
	public Company? Company { get; set; }

	public ICollection<DepartmentWorkers> DepartmentWorkers { get; set; }
}
