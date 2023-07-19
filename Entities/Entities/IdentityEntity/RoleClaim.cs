using Entities;
using Microsoft.AspNetCore.Identity;

namespace Entities;

public class RoleClaim:IdentityRoleClaim<long> , IBaseEntity
{
    
}