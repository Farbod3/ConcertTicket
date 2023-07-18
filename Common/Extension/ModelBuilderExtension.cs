using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Common.Extension;

public static class ModelBuilderExtension
{
   public static void AddAllEntities<TBase>(ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
      
      
        var entityTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && !t.IsGenericType && typeof(TBase)
                .IsAssignableFrom(t));
        foreach (var entityType in entityTypes)
        {
            modelBuilder.Entity(entityType);
        }
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TBase).Assembly);
        
    }
    
    
    
    
}