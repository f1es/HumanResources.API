using AutoMapper;
using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;
using HumanResources.Core.Models;

namespace HumanResources.Usecase.MapperProfiles;

public class ProfessionMapperProfile : Profile
{
    public ProfessionMapperProfile()
    {
        CreateMap<ProfessionRequestDto, Profession>();

        CreateMap<Profession, ProfessionResponseDto>();
    }
}
