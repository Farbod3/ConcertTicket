using Entities.BaseEntity;
using Microsoft.AspNetCore.Identity;

namespace Entities;

public class Role:IdentityRole<long>,IBaseEntity
{
    
}