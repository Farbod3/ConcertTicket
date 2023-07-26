using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class ConcertSelectDto : BaseDto<Concert,ConcertSelectDto,long>
{
    public string Title { get; set; }
    public string SingerName { get; set; }

    public List<Ticket> Tickets { get; set; }
    public long SingerId { get; set; }
    public Singer Singer { get; set; }
    
    public long ReservationId { get; set; }
    public Reservation Reservation { get; set; }
    public long CityId { get; set; }
    public City City { get; set; }
}