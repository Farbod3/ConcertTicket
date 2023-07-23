using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Entities.Tickets;

public class Ticket : BaseEntity
{
    public DateOnly Term { get; set; }
    public TimeOnly Time { get; set; }
    public string? Location { get; set; }
    public int Price { get; set; }

    public long CityId { get; set; }
    public City.City City { get; set; }
    public long SingerId { get; set; }
    public Singer.Singer Singer { get; set; }
    public long UserId { get; set; }
    public User User { get; set; }
    public long ArchiveId { get; set; }
    public Archive.Archive Archive { get; set; }
    public long ConcertId { get; set; }
    // public Concerts.Concerts Concerts { get; set; }
}

public class TicketTypeConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        //one city with many tickets
        builder.HasOne(a => a.City)
            .WithMany(b => b.Tickets)
            .HasForeignKey(c => c.CityId);
        builder.HasOne(g => g.Singer)
            .WithMany(h => h.Tickets)
            .HasForeignKey(i => i.SingerId);
        // builder.HasOne(j => j.Concerts)
        //     .WithMany(k => k.Tickets)
        //     .HasForeignKey(l => l.ConcertId);
    }
}