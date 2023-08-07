using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class Support : BaseEntity
{
    public int? PhoneNumber { get; set; }
    public string? Description { get; set; }
    public string? Location { get; set; }
    public string? Email { get; set; }
}

public class SupportTypeConfiguration : IEntityTypeConfiguration<Support>
{
    public void Configure(EntityTypeBuilder<Support> builder)
    {
        builder.Property(p=>p.PhoneNumber)
            .IsUnicode(true)
            .HasMaxLength(100)
            .IsConcurrencyToken()
            .IsRowVersion();
        builder.Property(d=>d.Description)
            .IsUnicode(true)
            .HasMaxLength(100)
            .IsConcurrencyToken()
            .IsRowVersion();
        builder.Property(l=>l.Location)
            .IsUnicode(true)
            .HasMaxLength(100)
            .IsConcurrencyToken()
            .IsRowVersion();
        builder.Property(e=>e.Email)
            .IsUnicode(true)
            .HasMaxLength(100)
            .IsConcurrencyToken()
            .IsRowVersion();
    }
}