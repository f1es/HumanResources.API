using AutoMapper;
using HumanResources.Core.Dto.Request;
using HumanResources.Core.Dto.Response;
using HumanResources.Core.Models;

namespace HumanResources.Usecase.MapperProfiles;
public class DepartmentMapperProfile : Profile
{
    public DepartmentMapperProfile()
    {
        CreateMap<DepartmentRequestDto, Department>();

        CreateMap<Department, DepartmentResponseDto>();
    }
}
