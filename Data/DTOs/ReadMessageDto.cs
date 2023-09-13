using SoulCoderzAPI.Enums;

namespace SoulCoderzAPI.Data.DTOs;

public class ReadMessageDto
{
  public RoleType Role { get; set; }
  public string Content { get; set; }
}