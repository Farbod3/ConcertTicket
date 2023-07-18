
using System.Reflection;
using Entities;
using Entities.BaseEntity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.MyAppDbContext;

public class AppDbContext : IdentityDbContext<User,Role,long,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      
        base.OnModelCreating(modelBuilder);
        var entityTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericType && typeof(IBaseEntity)
                .IsAssignableFrom(t));
        foreach (var entityType in entityTypes)
        {
            modelBuilder.Entity(entityType);
        }
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IBaseEntity).Assembly);
        
    }
    
}