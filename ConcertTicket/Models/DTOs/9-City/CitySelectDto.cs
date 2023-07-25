using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class CitySelectDto: BaseDto<City,CitySelectDto,long>
{
    public string? Title { get; set; }
    public DateTime Time { get; set; }
    public string Salon { get; set; }
    public List<Singer> Singers { get; set; }
    public List<Concert> Concerts { get; set; }
    public List<Ticket> Tickets { get; set; }
}