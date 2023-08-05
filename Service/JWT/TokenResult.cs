using System.IdentityModel.Tokens.Jwt;

namespace Service.JWT;

public class TokenResult
{
    public TokenResult(JwtSecurityToken token)
    {
        Token = token.RawData;
        Expire = 1;
        Type = "bearer";

    }

    public string Token { get; set; }
    public long Expire { get; set; }
    public string Type { get; set; }
}

public class Token
{
    public string JwtToken { get; set; }
    public string Type { get; set; }
    public long Expire { get; set; }
}