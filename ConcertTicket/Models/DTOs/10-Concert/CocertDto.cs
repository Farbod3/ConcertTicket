using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class CocertDto : BaseDto<Concert,CocertDto,long>
{
    public string Title { get; set; }
    public string SingerName { get; set; }

   
}