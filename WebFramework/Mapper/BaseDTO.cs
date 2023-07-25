using System.ComponentModel.DataAnnotations;
using AutoMapper;


namespace WebFramework.Mapper;

public class BaseDto <TSource, TDestination, TKey>
{
  
    [Display(Name = "Row")]
    public TKey? Id { get; set; }

    public void AddMapping (Profile profile)
    {
        var map = profile.CreateMap<TSource, TDestination>();
        MyCustomMapping(map);
    }
    public virtual void MyCustomMapping(IMappingExpression<TSource, TDestination> mapping)
    {
    }
    
}