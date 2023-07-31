// using System.IdentityModel.Tokens.Jwt;
// using System.Security.Claims;
// using System.Text;
// using Entities;
// using Microsoft.Extensions.Configuration;
// using Microsoft.IdentityModel.Tokens;
//
// namespace Service.JWT;
//
// public class JWTManager : IJWTManager
// {
//     Dictionary<string, string> UsersRecords = new Dictionary<string, string>
//     {
//         { "user1","password1"},
//         { "user2","password2"},
//         { "user3","password3"},
//     };
//
//     private readonly IConfiguration iconfiguration;
//     
//     public JWTManager(IConfiguration iconfiguration)
//     {
//         this.iconfiguration = iconfiguration;
//     }
//     public Tokens Authenticate(User user)
//     {
//         if (!UsersRecords.Any(x => x.Key == user.UserName && x.Value == user.PasswordHash)) {
//             return null;
//         }
//
//         // Else we generate JSON Web Token
//         var tokenHandler = new JwtSecurityTokenHandler();
//         var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
//         var tokenDescriptor = new SecurityTokenDescriptor
//         {
//             Subject = new ClaimsIdentity(new Claim[]
//             {
//                 new Claim(ClaimTypes.Name, user.UserName)                    
//             }),
//             Expires = DateTime.UtcNow.AddMinutes(1),
//             SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey),SecurityAlgorithms.HmacSha256Signature)
//         };
//         var token = tokenHandler.CreateToken(tokenDescriptor);
//         return new Tokens { Token = tokenHandler.WriteToken(token) };
//     }
// }