namespace HumanResources.Core.Models;

public class Company
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
	public DateTime BaseDate { get; set; }

	public Guid DirectorId { get; set; }
	public Director? Director { get; set; }

	public ICollection<Department>? Departments { get; set; }
	public ICollection<Vacancy>? Vacancies { get; set; }
}
