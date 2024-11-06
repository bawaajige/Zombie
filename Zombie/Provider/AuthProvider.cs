using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public Task<string> RegisterAsync(UserData userData)
    {
        if (string.IsNullOrWhiteSpace(userData.Username)) 
        {
            return Task.FromResult("Invalid Username");
        }
        
        bool userExists = db.UserDatas.Any(u => u.Username == userData.Username);

        if (!userExists)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, userData.Username)
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

            return Task.FromResult(tokenString);
        }
        else
        {
            return Task.FromResult("Username already taken");
        }
    }

    /// <inheritdoc />
    public Task<string> Login(UserData userData)
    {
        if (string.IsNullOrWhiteSpace(userData.Username)) 
        {
            return Task.FromResult("Invalid Username");
        }
        var checkUser = db.UserDatas.Any(u => u.Username == userData.Username && u.Password == userData.Password);
        if (checkUser)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, userData.Username)
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
            
            return Task.FromResult(tokenString);
        }
        else
        {
            return Task.FromResult("Ivalid Username or password");
        }
    }
}