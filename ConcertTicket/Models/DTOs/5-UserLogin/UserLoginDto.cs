using System.ComponentModel.DataAnnotations;
using Entities;
using WebFramework.Mapper;
using ValidationContext = AutoMapper.Configuration.ValidationContext;

namespace ConcertTicket.Models.DTOs;

public class UserLoginDto 
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    [DataType(DataType.Password)]

    public string? Password { get; set; }
    
}