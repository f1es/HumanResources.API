using AuthService.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AuthService.API.ContextFactory;

public class AuthContextFactory : IDesignTimeDbContextFactory<AuthDbContext>
{
	public AuthDbContext CreateDbContext(string[] args)
	{
		var configuration = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json")
			.Build();

		var builder = new DbContextOptionsBuilder<AuthDbContext>()
			.UseSqlServer(configuration.GetConnectionString("sqlConnection"),
			b => b.MigrationsAssembly("AuthService.Infrastructure"));

		return new AuthDbContext(builder.Options);
	}
}
