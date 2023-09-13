using System.ComponentModel.DataAnnotations;

namespace SoulCoderzAPI.Data.DTOs;

public class CreateUserDto
{
  [Required(ErrorMessage = "Username is required")]
  public string Username { get; set; }

  [Required(ErrorMessage = "Name is required")]
  public string Name { get; set; }

  [Required(ErrorMessage = "SurName is required")]
  public string SurName { get; set; }

  [Required(ErrorMessage = "Email is required")]
  public string Email { get; set; }

  [Required(ErrorMessage = "Password is required")]
  public string Password { get; set; }
}