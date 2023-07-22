namespace Entities.Entities.Singer;

public class Singer : BaseEntity
{
    public DateTime Time { get; set; }
    public string loccation { get; set; }
    public List<City.City> Cities { get; set; }

}