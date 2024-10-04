using Microsoft.EntityFrameworkCore;
using Zombie.Context;



var builder = WebApplication.CreateBuilder(args);
 
string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
 
builder.Services.AddDbContext<ZombieContext>(options => options.UseNpgsql(connection));
 
builder.Services.AddControllersWithViews();
 
var app = builder.Build();

app.MapDefaultControllerRoute();

app.Run();