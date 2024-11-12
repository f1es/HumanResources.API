using AuthService.Usecase.MapperProfiles;
using AuthService.Usecase.Services.Implementations;
using AuthService.Usecase.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AuthService.Usecase.Extensions;

public static class ServicesConfigurations
{
	public static void ConfigureUsecases(this IServiceCollection services)
	{
		services.AddScoped<IUserService, UserService>();	
	}

	public static void ConfigureMapper(this IServiceCollection services)
	{
		services.AddAutoMapper(options =>
		{
			options.AddProfile<UserMapperProfile>();
		});
	}
}
