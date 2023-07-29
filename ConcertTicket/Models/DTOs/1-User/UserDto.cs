using System.ComponentModel.DataAnnotations;
using Entities;
using WebFramework.Mapper;

namespace ConcertTicket.Models;

public class UserDto : BaseDto<User , UserDto , long>
{
    public string? FirstName { get; init; } 
    public string? LastName { get; init; }
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; init; }
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; } 
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public List<string>? Roles { get; init; } 
}