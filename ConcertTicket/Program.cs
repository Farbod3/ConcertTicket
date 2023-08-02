using System.Text;
using Data;
using Data.Repository.GenericRepository;
using Data.Repository.IGenericRepository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Service.IJWT;
using Service.JWT;
using WebFramework.Mapper;
using WebFramework.Middleware;
using WebFramework.ServiceExtension;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped (typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped(typeof(IJwt),typeof(Jwt));
builder.Services.AddAutoMapper(typeof(ICustomMapping));

var cs = builder.Configuration.GetConnectionString("sqlite")!;
builder.Services.AddSqlite<ConcertTicketDbContext>(cs);

builder.Services.AddAuthentication();
builder.Services.ConfigureJWT(builder.Configuration );
builder.Services.IdentityConfig();


var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<MyMiddleware>();

app.Run();