using Common.Extension;
using Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class 
    ConcertTicketDbContext : IdentityDbContext<User, Role, long, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
{
    public ConcertTicketDbContext(DbContextOptions<ConcertTicketDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        var assemblies = typeof(IBaseEntity).Assembly;

        modelBuilder.AddAllEntities<IBaseEntity>(assemblies);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IBaseEntity).Assembly);
        
        modelBuilder.Entity<User>()
            .HasKey(u => u.Id);
        modelBuilder.Entity<User>()
            .Property(u => u.FirstName)
            .IsRequired()
            .HasMaxLength(100);
     
    }
        
}