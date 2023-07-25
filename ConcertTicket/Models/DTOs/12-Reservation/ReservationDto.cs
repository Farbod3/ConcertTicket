using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class ReservationDto : BaseDto<Reservation, ReservationDto,long>
{
    public string Title { get; set; }
    public int PhoneNumber { get; set; }
    public int Password { get; set; }
    public List<Ticket>Tickets { get; set; }
    public List<Concert> Concerts { get; set; }
}