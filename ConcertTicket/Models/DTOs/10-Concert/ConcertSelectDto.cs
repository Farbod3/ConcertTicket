using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class ConcertSelectDto : BaseDto<Concert,ConcertSelectDto,long>
{
    public string? Image { get; set; }
    public string? Title { get; set; }
    public string? Location { get; set; }
    public string? CityName { get; set; }
    public string? Days { get; set; }
    public string Time { get; set; } 
    public string? Prices { get; set; }
    // public string? PhoneNumber { get; set; }
    public bool? IsActive { get; set; }

}