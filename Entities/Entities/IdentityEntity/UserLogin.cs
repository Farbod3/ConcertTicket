using Entities.BaseEntity;
using Microsoft.AspNetCore.Identity;

namespace Entities;

public class UserLogin : IdentityUserLogin<long>, IBaseEntity
{
    
}