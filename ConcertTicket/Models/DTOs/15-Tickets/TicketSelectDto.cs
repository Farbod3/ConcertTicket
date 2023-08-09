using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class TicketSelectDto : BaseDto<Ticket,TicketSelectDto,long>
{             
    public DateOnly Term { get; set; }
    public TimeOnly Time { get; set; }
    public string? Location { get; set; }
    public int Price { get; set; }
    
}