using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Entities;

public class Ticket : BaseEntity
{
    
    public string? Days { get; set; }
    public string? Time { get; set; }
    public string? Singer { get; set; }
    public string? CityName { get; set; }
    public string? Location { get; set; }
    public string? Price { get; set; }
    public int? Quantity { get; set; }
    public bool? IsActive { get; set; }



    
    

    public long? CityId { get; set; }
    public City? City { get; set; }
    // public long? SingerId { get; set; }
    // public Singer? Singer { get; set; }

    public long? UserId { get; set; }
    public User? User { get; set; }

    public long? ConcertId { get; set; }
    public Concert? Concert { get; set; }

    public long? ReservationId { get; set; }
    public Reservation? Reservation { get; set; }
}
#region Fluent&relations
public class TicketTypeConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        #region Fluent

        builder.Property(t => t.Days)
            .HasMaxLength(100);
              builder.Property(ti => ti.Time)
                  .HasMaxLength(100);
             builder.Property(l => l.Location)
                 .HasMaxLength(100);
             builder.Property(p => p.Price)
                 .HasMaxLength(100);
         
        #endregion
        
        // builder.HasOne(g => g.Singer)
        //     .WithMany(h => h.Tickets)
        //     .HasForeignKey(i => i.SingerId)
        //     .OnDelete(DeleteBehavior.Restrict);
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