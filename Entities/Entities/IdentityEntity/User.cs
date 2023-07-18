using Entities;
using Microsoft.AspNetCore.Identity;

namespace Entities;

public class User : IdentityUser<long>,IBaseEntity
{
    
}