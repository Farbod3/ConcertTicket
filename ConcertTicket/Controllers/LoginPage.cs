using ConcertTicket.Models;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
    public async Task<IActionResult> CreatUser([FromBody] UserDto userDto)
    {
        var user = new User
        {
            FirstName = userDto.FirstName,
            Email = userDto.Email,
            LastName = userDto.LastName,
            UserName = userDto.UserName,
        };
        if (userDto.UserName != null) await _userManager.CreateAsync(user, userDto.UserName);
        return Ok(user);
        
    }

    [HttpPost(nameof(LoginUser))]
    public async Task<IActionResult> LoginUser(long id)
    {
        var userlogin = await _userManager.FindByIdAsync(id.ToString());
        return Ok(userlogin);
    }
}