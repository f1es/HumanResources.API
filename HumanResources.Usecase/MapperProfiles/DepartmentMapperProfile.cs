using AutoMapper;
using HumanResources.Core.Models;
using HumanResources.Core.Shared.Dto.Request;
using HumanResources.Core.Shared.Dto.Response;

namespace HumanResources.Usecase.MapperProfiles;
public class DepartmentMapperProfile : Profile
{
    public DepartmentMapperProfile()
    {
        CreateMap<DepartmentRequestDto, Department>();

        CreateMap<Department, DepartmentResponseDto>();
    }
}
