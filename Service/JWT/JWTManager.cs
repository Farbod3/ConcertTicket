using System.IdentityModel.Tokens.Jwt;
using Entities;
using Microsoft.IdentityModel.Tokens;
using Service.IJWT;

namespace Service.JWT;

public class Jwt : IJwt
{
    public async Task<TokenResult> GenerateToken(User user)
    {
        var descrypt = new SecurityTokenDescriptor
        {
            Issuer = "ConcertTikect",
            Audience = "https://localhost:7055/",
            IssuedAt = DateTime.Now,
            Expires = DateTime.Now.AddMinutes(1 * 24 * 60),
            SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey("farbod123456789123456789123456789"u8.ToArray()),
                    SecurityAlgorithms.HmacSha256Signature),
            EncryptingCredentials = new EncryptingCredentials(
                new SymmetricSecurityKey("12345678912345678"u8.ToArray()),
                SecurityAlgorithms.Aes128CbcHmacSha256, SecurityAlgorithms.HmacSha256Signature)
            
        };
        var handler = new JwtSecurityTokenHandler();
        var secret = handler.CreateJwtSecurityToken(descrypt);
        return new TokenResult(secret);
    }
    
    // private readonly UserManager<User> _userManager;
    // private readonly IConfiguration _configuration;
    // private User? _user;
    // public Jwt(UserManager<User> userManager,  IConfiguration configuration)
    // {
    //     _userManager = userManager;
    //     _configuration = configuration;        
    // }
    //
    // public async Task<IdentityResult> RegisterUserAsync(User user)
    // {
    //     var result = await _userManager.CreateAsync( user.Password);
    //     return result;
    // }
    //
    // public async Task<bool> ValidateUserAsync(User login)
    // {
    //     if (login.UserName != null) _user = await _userManager.FindByNameAsync(login.UserName);
    //     var result = _user != null && await _userManager.CheckPasswordAsync(_user, login.Password.ToString());
    //     return result;
    // }
    //
    // public async Task<string> CreateTokenAsync()
    // {
    //     var signingCredentials = GetSigningCredentials();
    //     var claims = await GetClaims();
    //     var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
    //     return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
    // }
    // private SigningCredentials GetSigningCredentials()
    // {
    //     var jwtConfig = _configuration.GetSection("jwtConfig");
    //     var key = Encoding.UTF8.GetBytes(jwtConfig["Secret"]);
    //     var secret = new SymmetricSecurityKey(key);
    //     return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    // }
    // private async Task<List<Claim>> GetClaims()
    // {
    //     var claims = new List<Claim>
    //     {
    //         new Claim(ClaimTypes.Name, _user.UserName)
    //     };
    //     var roles = await _userManager.GetRolesAsync(_user);
    //     foreach (var role in roles)
    //     {
    //         claims.Add(new Claim(ClaimTypes.Role, role));
    //     }
    //     return claims;
    // }
    //
    // private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    // {
    //     var jwtSettings = _configuration.GetSection("JwtConfig");
    //     var tokenOptions = new JwtSecurityToken
    //     (
    //         issuer: jwtSettings["validIssuer"],
    //         audience: jwtSettings["validAudience"],
    //         claims: claims,
    //         expires: DateTime.Now.AddMinutes(Convert.ToDouble(jwtSettings["expiresIn"])),
    //         signingCredentials: signingCredentials
    //     );
    //     return tokenOptions;
    // }
    
}