using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class Concert : BaseEntity
{
    public string Title { get; set; }
    public string SingerName { get; set; }

    public List<Ticket> Tickets { get; set; }
    public long SingerId { get; set; }
    public Singer Singer { get; set; }
    
    public long ReservationId { get; set; }
    public Reservation Reservation { get; set; }
    public long CityId { get; set; }
    public City City { get; set; }

}
public class ConcertTypeConfiguration:IEntityTypeConfiguration<Concert>
{
    public void Configure(EntityTypeBuilder<Concert> builder)
    {
        builder.HasOne(a => a.Singer)
            .WithMany(b => b.Concerts)
            .HasForeignKey(c => c.SingerId);
        builder.HasOne(d => d.Reservation)
            .WithMany(e => e.Concerts)
            .HasForeignKey(f => f.ReservationId);
        builder.HasOne(g => g.City)
            .WithMany(h => h.Concerts)
            .HasForeignKey(i => i.CityId);

    }
}
