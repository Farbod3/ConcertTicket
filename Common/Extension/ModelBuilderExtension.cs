using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace Common.Extension;

public static class ModelBuilderExtension
{
   public static void AddAllEntities <TBase>(this ModelBuilder modelBuilder, params Assembly[] assemblies)
    {
      
      
        var entityTypes = assemblies.SelectMany(x => x.GetExportedTypes())
            .Where(y => y is { IsPublic: true, IsAbstract: false } && typeof(TBase)
                            .IsAssignableFrom(y) && y.IsSubclassOf(typeof(TBase)));
        foreach (var entityType in entityTypes)
        {
            modelBuilder.Entity(entityType);
        }
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(TBase).Assembly);
        
    }
}