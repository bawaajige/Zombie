using Microsoft.AspNetCore.Mvc;
using Zombie.Models;

namespace Zombie.Provider;

public interface IAuthProvider
{
    /// <summary>
    /// принимает username и шифрует данные
    /// </summary>
    /// <param name="userData"></param>
    /// <param name="username"></param>
    /// <returns>JWT токен</returns>
    Task<IActionResult> LoginAsync(UserData userData);
}