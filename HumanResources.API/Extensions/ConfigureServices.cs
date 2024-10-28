using HumanResources.Infrastructure.Context;
using HumanResources.Usecase.NamingPolicies;
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

	public static void ConfigureAuthentication(this IServiceCollection services)
	{
		services.AddAuthentication(config =>
		{
			config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		})
		.AddJwtBearer("Bearer", options =>
		{
			options.Authority = "https://localhost:44387/";
			options.RequireHttpsMetadata = true;
			options.Audience = "api1";
		});
		services.AddAuthorization();
	}
}
