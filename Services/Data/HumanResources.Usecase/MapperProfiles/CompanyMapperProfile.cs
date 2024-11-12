using AutoMapper;
using HumanResources.Core.Models;
using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;

namespace HumanResources.Usecase.MapperProfiles;

public class CompanyMapperProfile : Profile
{
    public CompanyMapperProfile()
    {
        CreateMap<CompanyRequestDto, Company>();

        CreateMap<Company, CompanyResponseDto>();
    }
}
