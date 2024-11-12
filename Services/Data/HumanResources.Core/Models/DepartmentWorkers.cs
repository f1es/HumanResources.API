namespace HumanResources.Core.Models;

public class DepartmentWorkers
{
	public Guid DepartmentId { get; set; }
	public Department Department { get; set; }

	public Guid WorkerId { get; set; }
	public Worker Worker { get; set; }
}
