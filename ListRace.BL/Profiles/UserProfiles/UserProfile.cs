using AutoMapper;
using ListRace.BL.DTOs;
using Microsoft.AspNetCore.Identity;

namespace ListRace.BL.Profiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<UserLoginDTO, IdentityUser>().ReverseMap();
        CreateMap<UserRegisterDTO, IdentityUser>().ReverseMap();
    }
}
