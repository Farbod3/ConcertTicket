using Entities.Tickets;

namespace Entities.Programs;

public class Programs : BaseEntity
{
    public List<Archive.Archive> Archives { get; set; }
    
}