using Entities;
using WebFramework.Mapper;

namespace ConcertTicket.Models;

public class UserSelectDto 
{
    public string? UserName { get; set; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
}