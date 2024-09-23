using AutoMapper;
using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;
using HumanResources.Core.Models;

namespace HumanResources.Usecase.MapperProfiles;

public class CompanyMapperProfile : Profile
{
    public CompanyMapperProfile()
    {
        CreateMap<CompanyRequestDto, Company>();

        CreateMap<Company, CompanyResponseDto>();
    }
}
