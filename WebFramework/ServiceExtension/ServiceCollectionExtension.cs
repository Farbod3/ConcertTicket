using System.Text;
using Data;
using Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace WebFramework.ServiceExtension;

public static class ServiceCollectionExtension
{
    public static void AddSqlite<TContext>(this IServiceCollection serviceCollection,
        string cs) where TContext : DbContext
    {
        serviceCollection.AddDbContext<TContext>(opt => opt.UseSqlite(cs));
    }

    public static void IdentityConfig(this IServiceCollection services)
    {
        var builder = services.AddIdentity<User , Role>(a =>
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

    public static void ConfigureJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtConfig = configuration.GetSection("jwtConfig");
        var secretKey = jwtConfig["secret"];
        services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                if (secretKey != null)
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ClockSkew = TimeSpan.Zero,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtConfig["validIssuer"],
                        ValidAudience = jwtConfig["validAudience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                    };
            });
    }
}