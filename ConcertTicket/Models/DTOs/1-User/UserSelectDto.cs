using Entities;
using WebFramework.Mapper;

namespace ConcertTicket.Models;

public class UserSelectDto : BaseDto<User , UserSelectDto , long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
}