using AuthService.Core.Dto.Request;
using AuthService.Core.Dto.Response;
using AuthService.Core.Models;
using AutoMapper;

namespace AuthService.Usecase.MapperProfiles;

public class UserMapperProfile : Profile
{
    public UserMapperProfile()
    {
        CreateMap<RegisterDto, User>();

        CreateMap<LoginDto, User>();

        CreateMap<User, UserResponseDto>();
    }
}
