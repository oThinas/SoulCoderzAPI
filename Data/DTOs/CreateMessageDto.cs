using System.ComponentModel.DataAnnotations;
using SoulCoderzAPI.Enums;

namespace SoulCoderzAPI.Data.DTOs;

public class CreateMessageDto
{
  [Required(ErrorMessage = "Role is required")]
  public RoleType Role { get; set; }

  [Required(ErrorMessage = "Content is required")]
  public string Content { get; set; }
}