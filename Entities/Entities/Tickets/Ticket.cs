using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.Entities.Tickets;

public class Ticket : BaseEntity
{
    public DateOnly Term { get; set; }
    public TimeOnly Time { get; set; }
    public string? Location { get; set; }
    public int Price { get; set; }

    public int CityId { get; set; }
    public City.City City { get; set; }
    public int SingerId { get; set; }
    public Singer.Singer Singer { get; set; }
}

public class TicketTypeConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasOne(p => p.City)
            .WithMany(x => x.Tickets);

    }
}