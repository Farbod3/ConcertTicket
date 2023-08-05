using System.ComponentModel.DataAnnotations;
using Entities;
using Microsoft.AspNetCore.Identity;

namespace Entities;

public  class User : IdentityUser<long>,IBaseEntity
{
    [Required]
    [MaxLength(100)]
    public string? FirstName { get; set; }
    [Required]
    [MaxLength(100)]
    public string? LastName { get; set; }
    [Required]
    [MaxLength(100)]
    public  string? Password { get; set; }
    
    public List<Ticket>? Tickets { get; set; }
}   