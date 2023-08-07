using Entities;
using Microsoft.AspNetCore.Identity;
using Service.JWT;

namespace Service.IJWT;

public interface IJwt
{
    Task<TokenResult> GenerateToken(User user);
}
