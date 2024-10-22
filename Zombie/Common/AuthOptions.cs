using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Zombie.Common;

public class AuthOptions
{
    public const string Issuer = "ZombieServer";
    public const string Audience = "ZombieShooter";
    private const string Key = "mysupersecret_secretsecretsecretkey!123";
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
}