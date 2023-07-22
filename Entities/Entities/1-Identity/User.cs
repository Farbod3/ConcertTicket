using Entities;
using Microsoft.AspNetCore.Identity;

namespace Entities;

public class User : IdentityUser<long>,IBaseEntity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}