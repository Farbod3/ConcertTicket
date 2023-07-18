
using System.Reflection;
using Entities;using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.MyAppDbContext;

public class ConcertTicketDbContext : IdentityDbContext<User,Role,long,UserClaim,UserRole,UserLogin,RoleClaim,UserToken>
{
    public ConcertTicketDbContext(DbContextOptions<ConcertTicketDbContext> options) : base(options)
    {
    }

}