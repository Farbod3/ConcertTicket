using System.ComponentModel.DataAnnotations;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public  class User : IdentityUser<long>,IBaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public List<Ticket>? Tickets { get; set; }
}

#region Fluent&Relation
  
 public class UserTypeConfiguration : IEntityTypeConfiguration<User>
 {
     public void Configure(EntityTypeBuilder<User> builder)
     {
         #region Fluent
            builder.Property(f=>f.FirstName)
                .HasMaxLength(100);
            builder.Property(l => l.LastName)
                .HasMaxLength(100);
             
           
            #endregion

            builder.HasMany(t => t.Tickets)
                .WithOne(u => u.User)
                .HasForeignKey(f => f.UserId)
                .OnDelete(DeleteBehavior.Restrict);
     }
 }

#endregion