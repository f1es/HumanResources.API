using AutoMapper;
using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;
using HumanResources.Core.Models;
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
