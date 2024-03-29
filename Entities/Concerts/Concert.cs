﻿using System.ComponentModel.DataAnnotations;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entities;

public class Concert : BaseEntity
{
    public string? ImageHome { get; set; }
    public string? ImageConcert { get; set; }

    public string? Title { get; set; }
    public string? Location { get; set; }
    public string? CityName { get; set; }
    public string? Days { get; set; }
    public string? Time { get; set; }  
    public string? Prices { get; set; }
    // public string? PhoneNumber { get; set; }
    public bool? IsActive { get; set; }
    
    
    // public string? SingerName { get; set; }
    // public long? ArchiveId { get; set; }
    // public Archive? Archive { get; set; }
    public List<Ticket>? Tickets { get; set; }
    // public long? SingerId { get; set; }
    // public Singer Singer { get; set; }


    public List<Reservation>? Reservations { get; set; }
    public long? CityId { get; set; }
    public City? City { get; set; }
}

#region Fluent&Relations
public class ConcertTypeConfiguration : IEntityTypeConfiguration<Concert>
{
    
    public void Configure(EntityTypeBuilder<Concert> builder)
    {

        #region Fluent

         builder.Property(t => t.Title)
            .HasMaxLength(100);
         // builder.Property(s => s.SingerName)
         //     .HasMaxLength(100);
        

        #endregion

        // builder.HasOne(a => a.Singer)
        //     .WithMany(b => b.Concerts)
        //     .HasForeignKey(c => c.SingerId);
        builder.HasOne(g => g.City)
            .WithMany(h => h.Concerts)
            .HasForeignKey(i => i.CityId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(j => j.Tickets)
            .WithOne(k => k.Concert)
            .HasForeignKey(l => l.ConcertId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.HasMany(m => m.Reservations)
            .WithMany(n => n.Concerts);
    }
}
#endregion