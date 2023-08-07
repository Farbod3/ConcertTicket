using System.ComponentModel.DataAnnotations;
using Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class Singer : BaseEntity
{
    public DateTime Time { get; set; }
    public string? loccation { get; set; }
    
    
    public List<City> Cities { get; set; }
    public List<Ticket> Tickets { get; set; }
    public List<Concert> Concerts { get; set; }
}
#region Fluent&Relations
public class SingerTypeConfiguration : IEntityTypeConfiguration<Singer>
{
    public void Configure(EntityTypeBuilder<Singer> builder)
    {
        #region Fluent
        builder.Property(t=>t.Time)
             .IsUnicode(true)
             .HasMaxLength(100)
             .IsConcurrencyToken()
             .IsRowVersion();
         builder.Property(l=>l.loccation)
             .IsUnicode(true)
             .HasMaxLength(100)
             .IsConcurrencyToken()
             .IsRowVersion();
         #endregion
        
        builder.HasMany(a => a.Cities)
            .WithMany(b => b.Singers);
        builder.HasMany(c => c.Tickets)
            .WithOne(d => d.Singer)
            .HasForeignKey(e => e.SingerId);
        builder.HasMany(f => f.Concerts)
            .WithOne(g => g.Singer)
            .HasForeignKey(h => h.SingerId);

    }
}
#endregion