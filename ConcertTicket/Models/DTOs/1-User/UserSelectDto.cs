using Entities;
using WebFramework.Mapper;

namespace ConcertTicket.Models;

public class UserSelectDto : BaseDto<User , UserSelectDto , long>
{
    public string UserName { get; set; }
    public string Password { get; set; }
    
}