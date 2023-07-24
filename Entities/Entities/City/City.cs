using Entities.Concerts;
using Entities.Tickets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities.City;

public class City : BaseEntity
{
    public string? Title { get; set; }
    public DateTime Time { get; set; }
    public string Salon { get; set; }
    public List<Singer.Singer> Singers { get; set; }
    public List<Concert> Concerts { get; set; }
    public List<Ticket> Tickets { get; set; }
}
public class CityTypeConfiguration: IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasMany(a => a.Singers)
            .WithMany(b => b.Cities);

    }
}
