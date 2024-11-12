﻿namespace HumanResources.Core.Models;

public class Vacancy
{
	public Guid Id { get; set; }
	public DateTime ReceiptDate { get; set; }
	public string? Description { get; set; }

	public Guid ProfessionId { get; set; }
	public Profession? Profession { get; set; }
	public Guid ComapnyId { get; set; }
	public Company? Company { get; set; }

}
