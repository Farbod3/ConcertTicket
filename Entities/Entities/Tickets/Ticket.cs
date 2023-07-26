using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class Ticket : BaseEntity
{
    public DateOnly Term { get; set; }
    public TimeOnly Time { get; set; }
    public string? Location { get; set; }
    public int Price { get; set; }

    public long CityId { get; set; }
    public City City { get; set; }
    public long SingerId { get; set; }
    public Singer Singer { get; set; }

    public long UserId { get; set; }
    public User User { get; set; }

    public long ConcertId { get; set; }
    public Concert Concert { get; set; }

    public long ReservationId { get; set; }
    public Reservation Reservation { get; set; }
}

public class TicketTypeConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasOne(a => a.City)
            .WithMany(b => b.Tickets)
            .HasForeignKey(c => c.CityId);
        builder.HasOne(g => g.Singer)
            .WithMany(h => h.Tickets)
            .HasForeignKey(i => i.SingerId);
        builder.HasOne(j => j.Concert)
            .WithMany(k => k.Tickets)
            .HasForeignKey(l => l.ConcertId);
        builder.HasOne(m => m.User)
            .WithMany(n => n.Tickets)
            .HasForeignKey(o => o.UserId);
        builder.HasOne(p => p.Reservation)
            .WithMany(q => q.Tickets)
            .HasForeignKey(r => r.ReservationId);
    }
}