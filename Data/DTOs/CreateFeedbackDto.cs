using System.ComponentModel.DataAnnotations;

namespace SoulCoderzAPI.Data.DTOs;

public class CreateFeedbackDto
{
  [Required(ErrorMessage = "MessageId is required")]
  public int MessageId { get; set; }

  [Required(ErrorMessage = "UserId is required")]
  public int UserId { get; set; }

  [Required(ErrorMessage = "Content is required")]
  public string Content { get; set; }
}