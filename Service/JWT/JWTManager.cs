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
                new SymmetricSecurityKey("1234567891234567"u8.ToArray()),
                SecurityAlgorithms.Aes128KW, SecurityAlgorithms.Aes128CbcHmacSha256)
            
        };
        var handler = new JwtSecurityTokenHandler();
        var secret = handler.CreateJwtSecurityToken(descrypt);
        return new TokenResult(secret);
    }
    
    
}