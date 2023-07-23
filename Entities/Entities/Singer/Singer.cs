using Entities.Concerts;
using Entities.Tickets;

namespace Entities.Singer;

public class Singer : BaseEntity
{
    public DateTime Time { get; set; }
    public string loccation { get; set; }
    
    public List<City.City> Cities { get; set; }
    public List<Ticket> Tickets { get; set; }
    public List<Concert> Concerts { get; set; }
}