using AutoMapper;
using HumanResources.Core.Models;
using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;

namespace HumanResources.Usecase.MapperProfiles;

public class ProfessionMapperProfile : Profile
{
    public ProfessionMapperProfile()
    {
        CreateMap<ProfessionRequestDto, Profession>();

        CreateMap<Profession, ProfessionResponseDto>();
    }
}
