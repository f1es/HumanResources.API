using AuthService.API.IdentityServerConfig;
using AuthService.Core.Models;
using AuthService.Infrastructure.Context;
using AuthService.Usecase.Services.Implementations;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthService.API.Extensions;

public static class ConfigureServices
{
	public static void ConfigureIdentityServer4(this IServiceCollection services)
	{
		services.AddIdentityServer(options =>
		{
			options.EmitStaticAudienceClaim = false;
		})
			.AddInMemoryClients(Configuration.GetClients())
			.AddInMemoryApiResources(Configuration.GetApiResources())
			.AddInMemoryIdentityResources(Configuration.GetIdentityResources())
			.AddInMemoryApiScopes(Configuration.GetApiScopes())
			.AddDeveloperSigningCredential()
			.AddAspNetIdentity<User>()
			.AddProfileService<ProfileService>();
	}

	public static void ConfigureDbContext(this IServiceCollection services, WebApplicationBuilder builder) =>
		services.AddDbContext<AuthDbContext>(options =>
		{
			options.UseSqlServer(builder.Configuration.GetConnectionString("sqlConnection"));
		});

	public static void ConfigureIdentity(this IServiceCollection services) =>
		services.AddIdentity<User, IdentityRole>(options =>
		{
			options.Password.RequireDigit = false;
			options.Password.RequiredLength = 1;
			options.Password.RequireNonAlphanumeric = false;
			options.Password.RequireUppercase = false;
			options.Password.RequireLowercase = false;
			options.Password.RequiredUniqueChars = 1;
			options.Lockout.AllowedForNewUsers = false;
		})
		.AddEntityFrameworkStores<AuthDbContext>()
		.AddDefaultTokenProviders();

	public static void ConfigureLogging(this IServiceCollection services)
	{
		services.AddLogging(builder =>
		{
			builder.AddConsole();
			builder.AddDebug();
		});
	}
}
