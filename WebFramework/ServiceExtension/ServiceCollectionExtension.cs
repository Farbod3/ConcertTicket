using Data;
using Data.Repository.GenericRepository;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebFramework.ServiceExtension;

public static class ServiceCollectionExtension
{
    public static void AddSqlite<TContext>(this IServiceCollection serviceCollection,
        string cs) where TContext : DbContext
    {
        serviceCollection.AddDbContext<TContext>(opt=>opt.UseSqlite(cs));
    }

    public static void IdentityConfig(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User,Role>(a =>
        {
            a.Password.RequireDigit = false;
            a.Password.RequireLowercase = false;
            a.Password.RequireUppercase = false;
            a.Password.RequireNonAlphanumeric = false;
            a.Password.RequiredLength = 1;
            a.User.RequireUniqueEmail = false;
        })
            .AddEntityFrameworkStores<ConcertTicketDbContext>()
            .AddDefaultTokenProviders();
    }
}