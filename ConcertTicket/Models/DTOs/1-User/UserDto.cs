
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ConcertTicket.Models;

public class UserDto : IValidatableObject
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? UserName { get; init; }
    public string? Password { get; init; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var userDto = (UserDto)validationContext.ObjectInstance;

        if (string.IsNullOrEmpty(userDto.FirstName))
            yield return new ValidationResult("FirstName is required!!");
        if (string.IsNullOrEmpty(userDto.LastName))
            yield return new ValidationResult("LastName is required!!");
        if (string.IsNullOrEmpty(userDto.UserName))
            yield return new ValidationResult("UserName is required!!");
        if (userDto.UserName.Length != 5)
            yield return new ValidationResult("UserName is too short");
        if (string.IsNullOrEmpty(userDto.Email))
            yield return new ValidationResult("Email is required!!");
        if (userDto.Email.Contains("@gmail.com") == false)
            yield return new ValidationResult("Invalid Email");
        if (string.IsNullOrEmpty(userDto.PhoneNumber))
            yield return new ValidationResult("PhoneNumber is required!!");
        if (userDto.PhoneNumber.Length != 10)
            yield return new ValidationResult("phineNumber is too short");

        
    }
    
}
