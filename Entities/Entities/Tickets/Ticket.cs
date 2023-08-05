using System.ComponentModel.DataAnnotations;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class Ticket : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public DateOnly Term { get; set; }
    [Required]
    [MaxLength(100)]
    public TimeOnly Time { get; set; }
    [Required]
    [MaxLength(100)]
    public string? Location { get; set; }
    [Required]
    [MaxLength(100)]
    public int Price { get; set; }

    public long? CityId { get; set; }
    public City City { get; set; }
    public long? SingerId { get; set; }
    public Singer Singer { get; set; }

    public long? UserId { get; set; }
    public User User { get; set; }

    public long? ConcertId { get; set; }
    public Concert Concert { get; set; }

    public long? ReservationId { get; set; }
    public Reservation Reservation { get; set; }
}
#region relations
public class TicketTypeConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
       
        builder.HasOne(g => g.Singer)
            .WithMany(h => h.Tickets)
            .HasForeignKey(i => i.SingerId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(j => j.Concert)
            .WithMany(k => k.Tickets)
            .HasForeignKey(l => l.ConcertId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(m => m.User)
            .WithMany(n => n.Tickets)
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(p => p.Reservation)
            .WithMany(q => q.Tickets)
            .HasForeignKey(r => r.ReservationId)
            .OnDelete(DeleteBehavior.Restrict); 
    }
}
#endregion