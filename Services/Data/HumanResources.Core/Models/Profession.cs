namespace HumanResources.Core.Models;

public class Profession
{
	public Guid Id { get; set; }
	public string? Name { get; set; }
	public decimal Salary { get; set; }

	public ICollection<Vacancy>? Vacancies { get; set; }
}
