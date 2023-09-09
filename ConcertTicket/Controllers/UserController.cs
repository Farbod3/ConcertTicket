using AutoMapper;
using ConcertTicket.Models;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.IJWT;
using Service.JWT;
using WebFramework.BaseController;
using UserLoginDto = ConcertTicket.Models.DTOs.UserLoginDto; 

namespace ConcertTicket.Controllers;

public class UserController : BaseController
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IJwtManager _Jwt;
    private readonly IMapper _mapping;

    public UserController(UserManager<User> userManager, IJwtManager jwt, IMapper mapper,
        SignInManager<User> signInManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _Jwt = jwt;
        _mapping = mapper;
    }


    [HttpPost]
    public async Task<ActionResult<UserSelectDto>> Signup([FromQuery] UserDto dto)
    {
        var code = "3223";
        var model = new User
        {
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Gender = dto.Gender,
            Email = dto.Email,
            UserName = dto.UserName,
            PhoneNumber = dto.PhoneNumber,
            SMSCode = dto.SMSCode
        };
        if (model.SMSCode != code)
        {
            return BadRequest("کد تأیید وارد شده صحیح نیست.");
        }

        await _userManager.CreateAsync(model, dto.Password!);
        var map = _mapping.Map<UserSelectDto>(model);
        return Ok(map);
    }


    [HttpPost]
    public async Task<ActionResult<Token>> LoginUser([FromQuery] UserLoginDto dto)
    {
        var user = await _userManager.FindByNameAsync(dto.UserName!);
        if (user == null)
        {
            return BadRequest("نام کاربری اشتباه است.");
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password!, true);
        if (!result.Succeeded)
        {
            return BadRequest("رمز عبور اشتباه است.");
        }

        await _signInManager.SignInAsync(user, true);

        var token = await _Jwt.GenerateToken(user);
        return new JsonResult(token);
        
        // var mm = await _userManager.FindByNameAsync(dto.UserName!);
        // var result = await _signInManager.PasswordSignInAsync(mm, dto.Password!, true, true);
        // var token = await _Jwt.GenerateToken(result);
        // return new JsonResult(token);
    }

    [HttpPost, Authorize]
    public async Task<ActionResult> ResetPassword(PasswordResetDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        return Ok();
    }
}