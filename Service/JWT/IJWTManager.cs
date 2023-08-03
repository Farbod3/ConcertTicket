using Entities;
using Microsoft.AspNetCore.Identity;
using Service.JWT;

namespace Service.IJWT;

public interface IJwt
{
    Task<TokenResult> GenerateToken(User user);

    // Task<IdentityResult> RegisterUserAsync(User user);   
    // Task<bool> ValidateUserAsync(User login); 
    // Task<string> CreateTokenAsync(); 
}
