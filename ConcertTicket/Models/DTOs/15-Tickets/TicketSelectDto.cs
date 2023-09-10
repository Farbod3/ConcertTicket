using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class TicketSelectDto : BaseDto<TicketSelectDto,Ticket,long>
{             
    public DateOnly? Term { get; set; }
    public TimeOnly? Time { get; set; }
    public string? Singer { get; set; }
    public string? City { get; set; }
    public string? Location { get; set; }
    public int? Price { get; set; }
    
}