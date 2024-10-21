using Microsoft.EntityFrameworkCore;
using Zombie.Context;
using Zombie.Provider;


var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ZombieContext>(options => options.UseNpgsql(connection));

builder.Services.AddControllers();

builder.Services.AddScoped<ISaveProvider, SaveProvider>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ZombieContext>();
context.Database.Migrate();


app.MapControllers();
app.Run();