using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class TicketSelectDto : BaseDto<Ticket,TicketSelectDto,long>
{             
    public DateOnly Term { get; set; }
    public TimeOnly Time { get; set; }
    public string? Location { get; set; }
    public int Price { get; set; }

    public long CityId { get; set; }
    public City City { get; set; }
    public long SingerId { get; set; }
    public Singer Singer { get; set; }
    
    public long UserId { get; set; }
    public User User { get; set; }
    
    public long ConcertId { get; set; }
    public Concert Concert { get; set; }
    
    public long ReservationId { get; set; }
    public Reservation Reservation { get; set; }
}