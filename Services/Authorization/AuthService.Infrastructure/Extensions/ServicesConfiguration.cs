using AuthService.Core.Repositories;
using AuthService.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Infrastructure.Extensions;

public static class ServicesConfiguration
{
	public static void ConfigureRepositories(this IServiceCollection services)
	{
		services.AddScoped<IRepositoryManager, RepositoryManager>();
	}
}
