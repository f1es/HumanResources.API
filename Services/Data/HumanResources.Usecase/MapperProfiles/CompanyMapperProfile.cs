using AutoMapper;
using HumanResources.Core.Models;
using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;
using HumanResources.Usecase.Usecases.Companies.Commands.CreateCompany;
using HumanResources.Usecase.Usecases.Companies.Commands.UpdateCompany;
using HumanResources.Usecase.Usecases.Companies.Queries.GetComapny;

namespace HumanResources.Usecase.MapperProfiles;

public class CompanyMapperProfile : Profile
{
    public CompanyMapperProfile()
    {
        CreateMap<CreateCompanyCommand, Company>();
        CreateMap<UpdateCompanyCommand, Company>();

        CreateMap<Company, CompanyModel>();
    }
}
