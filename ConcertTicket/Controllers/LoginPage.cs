using System.Security.Cryptography.X509Certificates;
using AutoMapper;
using ConcertTicket.Models;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V5.Pages.Account.Internal;
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

    [HttpPost("CreatUser")]
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
        
        // if (user1 != null && await _userManager.CheckPasswordAsync(user, model.Password))
        // {
        //     var token = GenerateJwtToken(user);
        //     return Ok(new { token, userDto });
        // }
    }

    [HttpPost("LoginUser")]
    public async Task<IActionResult> LoginUser(long id)
    {
        var userlogin = await _userManager.FindByIdAsync(id.ToString());
        return Ok(userlogin);
    }
}