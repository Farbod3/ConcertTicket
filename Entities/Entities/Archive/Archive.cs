using Entities.Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Entities.Archive;

public  class Archive : BaseEntity
{
    public List<Ticket> Tickets { get; set; }
    public Programs.Programs Programs { get; set; }
}

public class ArchiveTypeConfiguration : IEntityTypeConfiguration<Archive>
{
    public void Configure(EntityTypeBuilder<Archive> builder)
    {
        // builder.HasOne(p=> p.programs)
        //     .WithMany(x=> x. Ticket)
            
    }
}