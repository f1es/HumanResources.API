using AutoMapper;
using HumanResources.Core.Models;
using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;
using Microsoft.Extensions.Options;

namespace HumanResources.Usecase.MapperProfiles;

public class VacancyMapperProfile : Profile
{
    public VacancyMapperProfile()
    {
        CreateMap<VacancyRequestDto, Vacancy>()
            .ForMember(x => x.ReceiptDate, m => m.MapFrom(a => a.ReceiptDate))
            .ForMember(x => x.Description, m => m.MapFrom(a => a.Description))
            .ForMember(x => x.ProfessionId, m => m.MapFrom(a => a.ProffesionId));

        CreateMap<Vacancy, VacancyResponseDto>();
    }
}
