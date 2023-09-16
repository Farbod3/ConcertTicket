using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class TicketDto : BaseDto<TicketDto, Ticket,long>
{
    public string? Days { get; set; }
    public string? Time { get; set; }
    public string? Singer { get; set; }
    public string? CityName { get; set; }
    public string? Location { get; set; }
    public string? Price { get; set; }
    public int? Quantity { get; set; }
    public bool? IsActive { get; set; }

  
}