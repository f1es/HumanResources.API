using AutoMapper;
using HumanResources.Core.Models;
using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;

namespace HumanResources.Usecase.MapperProfiles;

public class WorkerMapperProfile : Profile
{
    public WorkerMapperProfile()
    {
        CreateMap<WorkerRequestDto, Worker>();

        CreateMap<Worker, WorkerResponseDto>();
    }
}
