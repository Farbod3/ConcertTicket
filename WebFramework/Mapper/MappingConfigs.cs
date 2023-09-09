using System.Reflection;
using AutoMapper;

namespace WebFramework.Mapper;

public class MappingConfigs : Profile
{
    public MappingConfigs()
    {
        var allTypes = Assembly.GetEntryAssembly()!.GetExportedTypes()
            .Where(p =>
                p is { IsClass: true, IsPublic: true, IsAbstract: false } && p.GetInterfaces().Contains(typeof(ICustomMapping)));
        
        foreach (var type in allTypes)
        {
            var dto = Activator.CreateInstance(type) as ICustomMapping;

            dto!.AddMapping(this);
        }   
    }
}