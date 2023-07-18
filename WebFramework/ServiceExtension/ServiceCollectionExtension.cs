﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace WebFramework.ServiceExtension;

public static class ServiceCollectionExtension
{
    public static void AddSqlite<TContext>(this IServiceCollection serviceCollection,
        string cs) where TContext : DbContext
    {
        serviceCollection.AddDbContext<TContext>(opt=>opt.UseSqlite(cs));
    }
}