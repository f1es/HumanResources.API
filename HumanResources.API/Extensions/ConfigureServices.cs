using HumanResources.Infrastructure.Context;
using HumanResources.Usecase.Converters;
using HumanResources.Usecase.NamingPolicies;
using Microsoft.EntityFrameworkCore;

namespace HumanResources.API.Extensions;

public static class ConfigureServices
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

	public static void ConfigureControllers(this IServiceCollection services) =>
		services.AddControllers()
		.AddJsonOptions(options =>
		{
			options.JsonSerializerOptions.PropertyNamingPolicy = new PascalCaseNamingPolicy();
		});
}
