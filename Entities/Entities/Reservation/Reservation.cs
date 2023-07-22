using Entities.Entities.Tickets;

namespace Entities.Entities.Reservation;

public class Reservation : BaseEntity
{
    public int PhoneNumber { get; set; }
    public List<Ticket>Tickets { get; set; }
}