using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResources.Infrastructure.Extensions;

public static class InfrastructureDIExtensions
{
	public static void ConfigureRepositories(this IServiceCollection services)
	{
		services.AddScoped<IRepositoryManager, RepositoryManager>();
	}
}
