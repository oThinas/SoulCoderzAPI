using System.ComponentModel.DataAnnotations;

namespace SoulCoderzAPI.Models;

public class Feedback
{
  [Key]
  [Required]
  public int Id { get; set; }

  [Required(ErrorMessage = "MessageId is required")]
  public int MessageId { get; set; }

  [Required(ErrorMessage = "UserId is required")]
  public int UserId { get; set; }

  [Required(ErrorMessage = "Content is required")]
  public string Content { get; set; }

}