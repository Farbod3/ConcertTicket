using System.ComponentModel.DataAnnotations;
using AutoMapper;


namespace WebFramework.Mapper;

public class BaseDto <TSource, TDestination, TKey> : ICustomMapping
{
    public TKey? Id { get; set; }
    
    public virtual TDestination ToEntity( )
    {
        IMapper mapper = null;
        return mapper.Map<TDestination>(this);
    }
        
    public virtual TSource ToSelectDto( )
    {
        IMapper mapper = null;
        return mapper.Map<TSource>(this);
    }

    public virtual void AddMapping(Profile profile)
    {
        profile.CreateMap<TSource,TDestination>().ReverseMap();
    }
  
    // [Display(Name = "Row")]
    // public TKey? Id { get; set; }
    //
    // public void AddMapping (Profile profile)
    // {
    //     var map = profile.CreateMap<TSource, TDestination>();
    //     MyCustomMapping(map);
    // }       
    // public virtual void MyCustomMapping(IMappingExpression<TSource, TDestination> mapping)
    // {
    // }
    
}