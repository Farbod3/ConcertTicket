using Entities.Entities.Tickets;

namespace Entities.Entities.City;

public class City : BaseEntity
{
    public DateTime Time { get; set; }
    public string Salon { get; set; }
    public List<Singer.Singer> Singers { get; set; }
    public List<Ticket> Tickets { get; set; }
}