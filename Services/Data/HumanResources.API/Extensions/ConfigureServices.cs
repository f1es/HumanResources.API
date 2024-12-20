using HumanResources.Infrastructure.Context;
using HumanResources.Usecase.NamingPolicies;
using HumanResources.Usecase.Services.Implementations;
using HumanResources.Usecase.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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

	public static void ConfigureLogger(this IServiceCollection services) =>
		services.AddSingleton<ILoggerManager, LoggerManager>();

	public static void ConfigureWebLogger(this IServiceCollection services)
	{
		services.AddSingleton<IWebLogger, WebLogger>();
	}

	public static void ConfigureDbContext(this IServiceCollection services, WebApplicationBuilder builder) =>
		services.AddDbContext<HumanResourcesDbContext>(options =>
		{
			//options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
			options.UseNpgsql(builder.Configuration.GetConnectionString("sqlConnection"));
		});

	public static void ConfigureControllers(this IServiceCollection services) =>
		services.AddControllers()
		.AddJsonOptions(options =>
		{
			options.JsonSerializerOptions.PropertyNamingPolicy = new PascalCaseNamingPolicy();
		});

	public static void ConfigureAuthentication(this IServiceCollection services)
	{
		services.AddAuthentication(config =>
		{
			config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer("Bearer", options =>
		{
			options.Authority = "http://localhost:5000";
			options.RequireHttpsMetadata = false;
			options.Audience = "api1";
		});
		services.AddAuthorization();
	}
}
