using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class SingerSelectDto : BaseDto<Singer,SingerSelectDto,long>
{
    public DateTime Time { get; set; }
    public string loccation { get; set; }
    
    public List<City> Cities { get; set; }
    public List<Ticket> Tickets { get; set; }
    public List<Concert> Concerts { get; set; }
}