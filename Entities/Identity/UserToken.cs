﻿using Entities;
using Microsoft.AspNetCore.Identity;

namespace Entities;

public class UserToken: IdentityUserToken<long>,IBaseEntity
{
    
}