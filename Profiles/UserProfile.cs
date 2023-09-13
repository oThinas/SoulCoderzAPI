using AutoMapper;
using SoulCoderzAPI.Data.DTOs;
using SoulCoderzAPI.Models;

namespace SoulCoderzAPI.Profiles;

public class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<CreateUserDto, User>();
    CreateMap<UpdateUserDto, User>();
    CreateMap<User, UpdateUserDto>();
    CreateMap<User, ReadUserDto>();
  }
}