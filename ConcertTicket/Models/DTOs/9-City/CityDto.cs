using Entities;
using Microsoft.VisualBasic.CompilerServices;
using WebFramework.Mapper;

namespace DTOs;

public class CityDto : BaseDto<City,CityDto,long>
{
    public string? Title { get; set; }
    public DateTime Time { get; set; }
    public string Salon { get; set; }
   
}

