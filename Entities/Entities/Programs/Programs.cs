using Entities.Entities.Tickets;

namespace Entities.Entities.Programs;

public class Programs : BaseEntity
{
    public IEnumerable<Archive.Archive>? Tickets { get; set; }
    public List<Archive.Archive> Archives { get; set; }
    
}