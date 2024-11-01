using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Zombie.Common;
using Zombie.Context;
using Zombie.Models;

namespace Zombie.Provider;

public class AuthProvider : IAuthProvider
{
    private ZombieContext db;

    public AuthProvider(ZombieContext context)
    {
        db = context;
    }

    /// <inheritdoc />
    public async Task<IActionResult> LoginAsync(UserData userData)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, userData.Username)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Issuer = AuthOptions.ISSUER,
            Audience = AuthOptions.AUDIENCE,
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(100),
            SigningCredentials =
                new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);
        
        db.UserDatas.Add(userData);
        db.SaveChangesAsync();
        
        return new OkObjectResult(new { Token = tokenString });
    }
}