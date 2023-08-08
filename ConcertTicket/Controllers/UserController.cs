using ConcertTicket.Models;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.IJWT;
using Service.JWT;
using WebFramework.BaseController;

namespace ConcertTicket.Controllers;

public class UserController : BaseController
{
    private readonly UserManager<User> _userManager; 
    private readonly IJwt _ijwt;

    public UserController(UserManager<User> userManager , IJwt ijwt)
    {
        _userManager = userManager;
        _ijwt = ijwt;
    }

    [HttpPost(nameof(CreatUser))]
    public async Task<IActionResult> CreatUser([FromBody] UserDto userDto )
    {
       
        var model = new User
        {
            FirstName = userDto.FirstName,
            Email = userDto.Email,
            LastName = userDto.LastName,
            UserName = userDto.UserName,
            PhoneNumber = userDto.PhoneNumber
        };
       var result = await _userManager.CreateAsync(model, userDto.Password!);
       return Ok(result);
    }
    
    [HttpPost(nameof(LoginUser))]
    public async Task<ActionResult<Token>> LoginUser([FromBody]UserDto dto)
    {
        var userlogin = await _userManager.FindByNameAsync(dto.UserName);
        var isPassword = await _userManager.CheckPasswordAsync(userlogin, dto.Password);

        var token = await _ijwt.GenerateToken(userlogin);
        return new JsonResult(token);
    }
    
}