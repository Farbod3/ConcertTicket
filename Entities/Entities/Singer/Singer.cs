using Entities;
using Entities;

namespace Entities;

public class Singer : BaseEntity
{
    public DateTime Time { get; set; }
    public string loccation { get; set; }
    
    public List<City> Cities { get; set; }
    public List<Ticket> Tickets { get; set; }
    public List<Concert> Concerts { get; set; }
}