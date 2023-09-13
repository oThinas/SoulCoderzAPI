using AutoMapper;
using SoulCoderzAPI.Data.DTOs;
using SoulCoderzAPI.Enums;
using SoulCoderzAPI.Models;

namespace SoulCoderzAPI.Profiles;

public class MessageProfile: Profile
{
  public MessageProfile()
  {
    CreateMap<CreateMessageDto, Message>();
    CreateMap<Message, ReadMessageDto>()
      .ForMember(dest => dest.Role, opt => opt.MapFrom(src => Enum.GetName(typeof(RoleType), src.Role)));
  }
}