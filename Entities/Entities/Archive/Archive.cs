using Entities.Concerts;
using Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Archive;

public  class Archive : BaseEntity
{
    public List<Concert> Concerts { get; set; }
    public long programsId { get; set; }
    public Programs.Programs Programs { get; set; }
}

public class ArchiveTypeConfiguration : IEntityTypeConfiguration<Archive>
{
    public void Configure(EntityTypeBuilder<Archive> builder)
    {
        builder.HasOne(p => p.Programs)
            .WithMany(x => x.Archives)
            .HasForeignKey(x => x.programsId);

    }
}