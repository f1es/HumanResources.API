using HumanResources.Core.Repositories;
using HumanResources.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResources.Infrastructure.Extensions;

public static class DIExtensions
{
	public static void ConfigureRepositories(this IServiceCollection services)
	{
		services.AddScoped<IRepositoryManager, RepositoryManager>();
	}
}
