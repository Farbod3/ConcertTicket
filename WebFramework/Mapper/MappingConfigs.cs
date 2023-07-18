using System.Reflection;
using AutoMapper;

namespace WebFramework.Mapper;

public class MappingConfigs : Profile
{
    public MappingConfigs()
    {
        var AllTypes = Assembly.GetEntryAssembly()!.GetExportedTypes()
            .Where(p =>
                p.IsClass && p.IsPublic && !p.IsAbstract && p.GetInterfaces().Contains(typeof(ICustomMapping)));
        
        foreach (var type in AllTypes)
        {
            var Dto = Activator.CreateInstance(type) as ICustomMapping;

            Dto!.ApplyMapping(this);
        }
    }
}