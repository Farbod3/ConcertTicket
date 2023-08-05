using System.ComponentModel.DataAnnotations;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class Concert : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }
    [Required]
    [MaxLength(100)]
    public string? SingerName { get; set; }

    public long? ArchiveId { get; set; }
    public Archive Archive { get; set; }
    public List<Ticket> Tickets { get; set; }
    public long? SingerId { get; set; }
    public Singer Singer { get; set; }


    public List<Reservation> Reservations { get; set; }
    public long? CityId { get; set; }
    public City City { get; set; }
}

#region relations
public class ConcertTypeConfiguration : IEntityTypeConfiguration<Concert>
{
    public void Configure(EntityTypeBuilder<Concert> builder)
    {
        builder.HasOne(a => a.Singer)
            .WithMany(b => b.Concerts)
            .HasForeignKey(c => c.SingerId);
        builder.HasOne(g => g.City)
            .WithMany(h => h.Concerts)
            .HasForeignKey(i => i.CityId);
        builder.HasMany(j => j.Tickets)
            .WithOne(k => k.Concert)
            .HasForeignKey(l => l.ConcertId);
        builder.HasMany(m => m.Reservations)
            .WithMany(n => n.Concerts);
    }
}
#endregion