using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class Archive : BaseEntity
{
    public string Title { get; set; }

    public List<Concert> Concerts { get; set; }
    public long programsId { get; set; }
    public Programs Programs { get; set; }
}

#region relations
public class ArchiveTypeConfiguration : IEntityTypeConfiguration<Archive>
{
    public void Configure(EntityTypeBuilder<Archive> builder)
    {
        builder.HasOne(a => a.Programs)
            .WithMany(b => b.Archives)
            .HasForeignKey(c => c.programsId);
        builder.HasMany(d => d.Concerts)
            .WithOne(e => e.Archive)
            .HasForeignKey(f => f.ArchiveId);
    }
}
#endregion