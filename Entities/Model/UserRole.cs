﻿using Entities.BaseEntity;
using Microsoft.AspNetCore.Identity;

namespace Entities;

public class UserRole : IdentityUserRole<long>,IBaseEntity
{
    
}