using Microsoft.AspNetCore.Mvc;

namespace Zombie.Provider;

public interface IAuthProvider
{
    /// <summary>
    /// принимает username и шифрует данные
    /// </summary>
    /// <param name="username"></param>
    /// <returns>JWT токен</returns>
    IActionResult Login(string username);
}