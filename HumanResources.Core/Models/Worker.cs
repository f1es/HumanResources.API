namespace HumanResources.Core.Models;

public class Worker
{
	public Guid Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Phone { get; set; }
	public DateTime Birthday { get; set; }

	public Guid SpecialityId { get; set; }
	public Speciality? Speciality { get; set; }
	//public Guid StateId { get; set; }
	//public State? State { get; set; }
	public ICollection<Department>? Departments { get; set; }
}
