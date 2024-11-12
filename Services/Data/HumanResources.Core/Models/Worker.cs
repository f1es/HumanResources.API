﻿namespace HumanResources.Core.Models;

public class Worker
{
	public Guid Id { get; set; }
	public string? FirstName { get; set; }
	public string? LastName { get; set; }
	public string? Phone { get; set; }
	public DateTime Birthday { get; set; }
	public ICollection<DepartmentWorkers> DepartmentWorkers { get; set; }
}
