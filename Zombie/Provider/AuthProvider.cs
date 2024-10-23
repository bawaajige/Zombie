using System.Text;

namespace Zombie.Provider;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Common;

public class AuthProvider : IAuthProvider
{
    public IActionResult Login(string username)
    {
        var claims = new List<Claim> { new Claim(ClaimTypes.Name, username) };

        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(100),
            SigningCredentials = 
                new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new OkObjectResult(new { Token = tokenString });
    }
}