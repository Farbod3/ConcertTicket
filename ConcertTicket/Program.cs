using Data;
using Data.Repository.GenericRepository;
using Data.Repository.IGenericRepository;
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

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#region Static File Setup
app.UseFileServer(new FileServerOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "View")),
    RequestPath = "/View",
    EnableDefaultFiles = true
});
#endregion


app.UseHttpsRedirection();


app.UseAuthorization();

app.MapControllers();

app.Run();