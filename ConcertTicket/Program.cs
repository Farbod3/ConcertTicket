using Data;
using Data.Repository.GenericRepository;
using Data.Repository.IGenericRepository;
using Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.FileProviders;
using WebFramework.Mapper;
using WebFramework.ServiceExtension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped (typeof(IRepository<>),typeof(Repository<>));

builder.Services.AddAutoMapper(typeof(ICustomMapping));

var cs = builder.Configuration.GetConnectionString("sqlite")!;
builder.Services.AddSqlite<ConcertTicketDbContext>(cs);

builder.Services.AddAuthentication(); 
builder.Services.IdentityConfig();

//   builder.Services.AddIdentity<User, Role>(options => { })
//     .AddEntityFrameworkStores<ConcertTicketDbContext>()
//     .AddDefaultTokenProviders();

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

app.Run();