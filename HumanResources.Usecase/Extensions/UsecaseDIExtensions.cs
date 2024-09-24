using HumanResources.Usecase.MapperProfiles;
using HumanResources.Usecase.Services.Implementations;
using HumanResources.Usecase.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace HumanResources.Usecase.Extensions;

public static class UsecaseDIExtensions
{
	public static void ConfigureServices(this IServiceCollection services)
	{
		services.AddScoped<ICompanyService, CompanyService>();
		services.AddScoped<IDepartmentService, DepartmentService>();
	}

	public static void ConfigureMapperProfiles(this IServiceCollection services)
	{
		services.AddAutoMapper(options =>
		{
			options.AddProfile<CompanyMapperProfile>();
			options.AddProfile<DepartmentMapperProfile>();
		});
	}
}
