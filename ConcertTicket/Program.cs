using Data;
using WebFramework.Mapper;
using WebFramework.Middleware;
using WebFramework.ServiceExtension;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using WebFramework.FarbodAutoFac;


var builder = WebApplication.CreateBuilder(args);
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(parameter => { parameter.RegisterModule(new FarbodAutoFac()); });


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddMySwagger();
var cs = builder.Configuration.GetConnectionString("sqlite")!;
builder.Services.AddSqlite<ConcertTicketDbContext>(cs);
builder.Services.AddSwaggerGen(opt =>
{
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Enter Token!",
        Name = "Auth",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[]{}
        }
    });
});

builder.Services.AddLogging();
// builder.Services.AddScoped (typeof(IRepository<>),typeof(Repository<>));
// builder.Services.AddScoped(typeof(IJwtManager),typeof(JwtManager));
builder.Services.AddAutoMapper(typeof(ICustomMapping));

// builder.Services.AddDbContext<ConcertTicketDbContext>(p =>
//     p.UseSqlite(builder.Configuration.GetConnectionString("sqlite")));


builder.Services.AddAuthentication();
builder.Services.ConfigureJwt(builder.Configuration );
builder.Services.IdentityConfig();


var app = builder.Build();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();
app.MyMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();