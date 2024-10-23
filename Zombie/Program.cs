using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Zombie.Common;
using Zombie.Context;
using Zombie.Provider;


var builder = WebApplication.CreateBuilder(args);

string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ZombieContext>(options => options.UseNpgsql(connection));

builder.Services.AddControllers();

builder.Services.AddScoped<ISaveProvider, SaveProvider>();
builder.Services.AddScoped<IAuthProvider, AuthProvider>();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidIssuer = AuthOptions.ISSUER,
            ValidateAudience = false,
            ValidAudience = AuthOptions.AUDIENCE,
            ValidateLifetime = true,
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            ValidateIssuerSigningKey = true,
        };
    });

var app = builder.Build();
using var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<ZombieContext>();
context.Database.Migrate();


app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();