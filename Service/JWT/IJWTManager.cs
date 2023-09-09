using Entities;
using Microsoft.AspNetCore.Identity;
using Service.JWT;

namespace Service.IJWT;

public interface IJwtManager
{
    Task<TokenResult> GenerateToken(User signInResult);

}
