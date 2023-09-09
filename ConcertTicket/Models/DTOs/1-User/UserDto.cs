
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;

namespace ConcertTicket.Models;

public class UserDto : IValidatableObject
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Gender { get; set; }
    public string? UserName { get; init; }
    
    // [DataType(DataType.Password)]
    public string? Password { get; init; }
    public string? SMSCode { get; set; }
    public string? Email { get; init; }
    public string? PhoneNumber { get; init; }
    
    #region Validation
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var userDto = (UserDto)validationContext.ObjectInstance;
    
        if (string.IsNullOrEmpty(userDto.FirstName))
            yield return new ValidationResult("FirstName is required!!");
        
        if (string.IsNullOrEmpty(userDto.LastName))
            yield return new ValidationResult("LastName is required!!");
        
        if (string.IsNullOrEmpty(userDto.UserName))
            yield return new ValidationResult("UserName is required!!");
        if (string.IsNullOrEmpty(userDto.Gender))
            yield return new ValidationResult("جنسیت خود را وارد کنید");
        if (userDto.UserName.Length < 3)
            yield return new ValidationResult("UserName is too short");
        
        if (string.IsNullOrEmpty(Email))
        {
            yield return new ValidationResult("لطفا ایمیل خود را وارد کنید.");
        }
        else
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            if (!Regex.IsMatch(Email, emailPattern))
            {
                yield return new ValidationResult("ایمیل نامعتبر است.");
            }
        }
        
        if (string.IsNullOrEmpty(PhoneNumber))
        {
            yield return new ValidationResult("شماره خود را وارد کنید");
        }
        else if (!Regex.IsMatch(PhoneNumber, @"^\+?[\d\s-]+$") || PhoneNumber.Length != 11 ||
                 !PhoneNumber.StartsWith("09"))
        {
            yield return new ValidationResult("لطفا شماره خود را به درستی وارد کنید.");
        }

        if (string.IsNullOrEmpty(Password))
        {
            yield return new ValidationResult("پسورد خود را وارد کنید");
        }
        else
        {
            string passPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
            if (!Regex.IsMatch(Password, passPattern))
            {
                yield return new ValidationResult(
                    "حداقل باید 8 کارکتر ، یک حرف بزگ ، یک حرف کوچک ،یک عدد و یک کارکتر مثل @ ، داشته باشد");
            }
        }
    
        
    }
    #endregion
}
