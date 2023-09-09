using Entities;
using WebFramework.Mapper;

namespace ConcertTicket.Models.DTOs;

public class UserLoginSelectDto : BaseDto<UserLogin , UserLoginSelectDto , long>
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
}