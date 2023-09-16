using Entities;
using Iran.AspNet.CountryDivisions;
using Microsoft.VisualBasic.CompilerServices;
using WebFramework.Mapper;

namespace DTOs;

public class CityDto : BaseDto<CityDto,City,long>
{
    public string? Title { get; set; }
    public string? CityCode { get; set; }

    // public IIranCountryDivisions _iranCountryDivisions = 
    //     new IranCountryDivisions(new Iran.AspNet.CountryDivisions.Data.DatabaseContext.LocationsDbContext());
    // public DateTime Time { get; set; }
    // public string Salon { get; set; }
    //
}

