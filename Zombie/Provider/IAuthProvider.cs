using Microsoft.AspNetCore.Mvc;
using Zombie.Models;

namespace Zombie.Provider;

public interface IAuthProvider
{
    /// <summary>
    /// принимает username и шифрует данные, проверяет полученные данные и совпадения в бд
    /// </summary>
    /// <param name="userData"></param>
    /// <param name="username"></param>
    /// <returns>JWT токен</returns>
    Task<string> RegisterAsync(UserData userData);
    
    /// <summary>
    /// принимает данные и сверяет с базой данных
    /// </summary>
    /// <param name="userData"></param>
    /// <returns>JWT токен</returns>
    Task<string> Login(UserData userData);
}