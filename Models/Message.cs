using System.ComponentModel.DataAnnotations;
using SoulCoderzAPI.Enums;

namespace SoulCoderzAPI.Models;

public class Message
{
  [Key]
  [Required]
  public int Id { get; set; }

  [Required(ErrorMessage = "Role is required")]
  public RoleType Role { get; set; }

  [Required(ErrorMessage = "Content is required")]
  public string Content { get; set; }
}