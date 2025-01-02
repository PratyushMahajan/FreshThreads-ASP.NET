using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using FreshThreads.Contexts;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Optionally, add any services that use the connection string, e.g., DbContext
builder.Services.AddDbContext<ApplicationDBContext>(options =>
   options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));


var app = builder.Build();
//var configuration = new ConfigurationBuilder()
//    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
//    .AddEnvironmentVariables()
//    .Build();
//string connectionString = configuration.GetConnectionString("DefaultConnection");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
