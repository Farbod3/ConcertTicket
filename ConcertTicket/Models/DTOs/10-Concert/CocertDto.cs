using System.ComponentModel.DataAnnotations;
using Entities;
using WebFramework.Mapper;

namespace DTOs;

public class CocertDto : BaseDto<Concert, CocertDto, long>
{
    public string? ImageHome { get; set; }
    public string? ImageConcert { get; set; }
    public string? Title { get; set; }
    public string? Location { get; set; }
    public string? CityName { get; set; }
    public string? Days { get; set; }
    public string? Time { get; set; } 
    public string? Prices { get; set; }
    // public string? PhoneNumber { get; set; }
    public bool? IsActive { get; set; }
    public long? ConcertId { get; set; }

}