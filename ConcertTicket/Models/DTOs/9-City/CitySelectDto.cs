using Entities;
using Iran.AspNet.CountryDivisions;
using WebFramework.Mapper;

namespace DTOs;

public class CitySelectDto: BaseDto<CitySelectDto,City,long>
{
    public string? Title { get; set; }
    public string? CityCode { get; set; }

    // public IIranCountryDivisions _iranCountryDivisions = 
    //     new IranCountryDivisions(new Iran.AspNet.CountryDivisions.Data.DatabaseContext.LocationsDbContext());
    // public DateTime Time { get; set; }
    // public string Salon { get; set; }
    // public List<Singer> Singers { get; set; }
    // public List<Concert> Concerts { get; set; }
    // public List<Ticket> Tickets { get; set; }
}