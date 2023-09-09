using System.ComponentModel.DataAnnotations;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class User : IdentityUser<long>, IBaseEntity
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Gender { get; set; }
    public string? SMSCode { get; set; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public List<Ticket>? Tickets { get; set; }
}

#region Fluent&Relation

public class UserTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        #region Fluent

        builder.Property(f => f.FirstName)
            .HasMaxLength(100);
        builder.Property(l => l.LastName)
            .HasMaxLength(100);
        builder.Property(g => g.Gender)
            .HasMaxLength(50);
        builder.Property(s => s.SMSCode)
            .HasMaxLength(50);
        builder.Property(e => e.Email)
            .HasMaxLength(100);
        builder.Property(p => p.PhoneNumber)
            .HasMaxLength(50);

        #endregion

        builder.HasMany(t => t.Tickets)
            .WithOne(u => u.User)
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

#endregion