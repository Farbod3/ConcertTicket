using Entities.Entities.Tickets;

namespace Entities.Entities.Programs;

public class Programs : BaseEntity
{
    public List<Ticket> Tickets { get; set; }
    public List<Archive.Archive> Archives { get; set; }
    
}