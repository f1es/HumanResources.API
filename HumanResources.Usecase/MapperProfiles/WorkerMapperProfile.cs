using AutoMapper;
using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;
using HumanResources.Core.Models;

namespace HumanResources.Usecase.MapperProfiles;

public class WorkerMapperProfile : Profile
{
    public WorkerMapperProfile()
    {
        CreateMap<WorkerRequestDto, Worker>();

        CreateMap<Worker, WorkerResponseDto>();
    }
}
