using Entities;
using WebFramework.Mapper;

namespace ConcertTicket.Models;

public class UserSelectDto  : BaseDto<User,UserSelectDto,long>
{
    public string? PhoneNumber { get; set; }
    
    public string? UserName { get; set; }
    
    public string? FirstName { get; init; }
    public string? LastName { get; set; }
    
    
}