using HumanResources.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace HumanResources.Infrastructure.Context;

public class HumanResourcesDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public HumanResourcesDbContext()
    { }
    public HumanResourcesDbContext(DbContextOptions<HumanResourcesDbContext> options, IConfiguration configuration) : 
        base(options)
    { 
        _configuration = configuration;
    }

    DbSet<Company>? Companies { get; set; }
    DbSet<Department>? Departments { get; set; }
    DbSet<Employee>? Employees { get; set; }
    DbSet<Profession>? Professions { get; set; }
    DbSet<Speciality>? Specialities { get; set; }
    DbSet<Vacancy>? Vacancies { get; set; }
    DbSet<Worker>? Workers { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
	}
	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("sqlConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
		base.OnConfiguring(optionsBuilder);
	}
}
