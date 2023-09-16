using System.ComponentModel.DataAnnotations;
using Iran.AspNet.CountryDivisions;
using Iran.AspNet.CountryDivisions.Data.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class City : BaseEntity
{
    public string? Title { get; set; }
    public string? CityCode { get; set; }
    // public DateTime Time { get; set; }
    // public string? plase { get; set; }

    // public IIranCountryDivisions _iranCountryDivisions = 
    //     new IranCountryDivisions(new Iran.AspNet.CountryDivisions.Data.DatabaseContext.LocationsDbContext());
    
    // public List<Singer>? Singers { get; set; }
    public List<Concert>? Concerts { get; set; }
    
}

#region Fluent&Relation
public class CityTypeConfiguration : IEntityTypeConfiguration<City>
{
    public void Configure(EntityTypeBuilder<City> builder)
    {
        #region Fluent

        builder.Property(t => t.Title)
            .IsUnicode(true)
            .HasMaxLength(100);
            
          
          // builder.Property(ti=>ti.Time)
          //     .IsUnicode(true)
          //         .HasMaxLength(100)
          //         .IsConcurrencyToken()
          //         .IsRowVersion();
          // builder.Property(p=>p.plase)
          //     .IsUnicode(true)
          //     .HasMaxLength(100)
          //     .IsConcurrencyToken()
          //     .IsRowVersion();
          #endregion
        // builder.HasMany(a => a.Singers)
        //     .WithMany(b => b.Cities);
        builder.HasMany(c => c.Concerts)
            .WithOne(d => d.City)
            .HasForeignKey(e => e.CityId);
      
    }
}
#endregion