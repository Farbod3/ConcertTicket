using System.ComponentModel.DataAnnotations;

namespace Entities;

public class Support : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public int? PhoneNumber { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Description { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Location { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Email { get; set; }
}