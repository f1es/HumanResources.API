using HumanResources.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.API.Extensions;

public static class ApiDIExtensions
{
	public static void ConfigureCors(this IServiceCollection services) =>
	services.AddCors(options =>
	{
		options.AddPolicy("CorsPolicy", builder =>
		builder.AllowAnyOrigin()
		.AllowAnyMethod()
		.AllowAnyHeader());
	});

	public static void ConfigureDbContext(this IServiceCollection services, WebApplicationBuilder builder) =>
		services.AddDbContext<HumanResourcesDbContext>(options =>
		{
			options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
		});
}
