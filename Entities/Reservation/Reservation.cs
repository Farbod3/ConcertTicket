using System.ComponentModel.DataAnnotations;
using Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class Reservation : BaseEntity
{
    public string? Title { get; set; }
    public int? PhoneNumber { get; set; }
    public string? Password { get; set; }
    
    
    public List<Ticket>Tickets { get; set; }
    public List<Concert> Concerts { get; set; }
}

#region Fluent
public class ReservationTypeConfiguration : IEntityTypeConfiguration<Reservation>
 {
     public void Configure(EntityTypeBuilder<Reservation> builder)
     {
         builder.Property(t=>t.Title)
             .IsUnicode(true)
             .HasMaxLength(100)
             .IsConcurrencyToken()
             .IsRowVersion();
         builder.Property(p=>p.PhoneNumber)
             .IsUnicode(true)
             .HasMaxLength(100)
             .IsConcurrencyToken()
             .IsRowVersion();
         builder.Property(pa=>pa.Password)
             .IsUnicode(true)
             .HasMaxLength(100)
             .IsConcurrencyToken()
             .IsRowVersion();
     }
 }
#endregion