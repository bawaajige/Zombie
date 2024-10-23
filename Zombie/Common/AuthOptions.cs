using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Zombie.Common;

public class AuthOptions
{
    public const string ISSUER = "ZombieServer";
    public const string AUDIENCE = "ZombieShooter";
    private const string KEY = "mysupersecret_secretsecretsecretkey!123";
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
}