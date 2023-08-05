using System.ComponentModel.DataAnnotations;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class City : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string? Title { get; set; }
    [Required]
    [MaxLength(100)]
    public DateTime Time { get; set; }
    [Required]
    [MaxLength(100)]
    public string plase { get; set; }
    public List<Singer> Singers { get; set; }
    public List<Concert> Concerts { get; set; }
    
}

#region relations
public class CityTypeConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        builder.HasMany(a => a.Singers)
            .WithMany(b => b.Cities);
        builder.HasMany(c => c.Concerts)
            .WithOne(d => d.City)
            .HasForeignKey(e => e.CityId);
      
    }
}
#endregion