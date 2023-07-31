using System.Security.Claims;
using System.Text;
using ConcertTicket.Models;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WebFramework.BaseController;

namespace ConcertTicket.Controllers;

public class LoginPage : BaseController
{
    private readonly UserManager<User> _userManager;

    public LoginPage(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    [HttpPost(nameof(CreatUser))]
    public async Task<IActionResult> CreatUser([FromBody] UserDto userDto )
    {
        // string passwordHash
        //     = BCrypt.Net.BCrypt.HashPassword(userDto.Password);
        var user = new User
        {
            FirstName = userDto.FirstName,
            PasswordHash = userDto.Password,
            Email = userDto.Email,
            LastName = userDto.LastName,
            UserName = userDto.UserName,
            PhoneNumber = userDto.PhoneNumber
        };
        await _userManager.CreateAsync(user, userDto.Password);
        return Ok(user);
    }
    [HttpPost(nameof(LoginUser))]
    public async Task<IActionResult> LoginUser(long id)
    {
        var userlogin = await _userManager.FindByIdAsync(id.ToString());
        return Ok(userlogin);
    }
    // private string CreateToken(User user)
    // {
    //     List<Claim> claims = new List<Claim>
    //     {
    //         new Claim(ClaimTypes.Role, user.UserName)
    //     };
    //     var Key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_userManager.) );
    // }
}