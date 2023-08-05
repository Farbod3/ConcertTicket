using System.ComponentModel.DataAnnotations;
using Entities;
using Entities;

namespace Entities;

public class Reservation : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }
    [Required]
    [MaxLength(100)]
    public int? PhoneNumber { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Password { get; set; }
    public List<Ticket>Tickets { get; set; }
    public List<Concert> Concerts { get; set; }
}