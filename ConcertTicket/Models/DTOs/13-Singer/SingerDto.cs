using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class SingerDto : BaseDto<Singer,SingerDto,long>
{
    public DateTime? Time { get; set; }
    public string loccation { get; set; }
    
}