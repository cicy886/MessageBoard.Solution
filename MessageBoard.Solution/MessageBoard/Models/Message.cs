using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
  public class Message
  {
    public int MessageId { get; set; }
    [Required]
    [StringLength(20)]
    public string UserName {get; set; }
    [Required]
    [Range(0, 150, ErrorMessage = "Age must be between 0 and 150.")]
    public int Age { get; set; }
    [Required]
    public string Date { get; set; }
    [Required]
    public string MessageDescription { get; set; }
  }
}