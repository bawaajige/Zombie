using Microsoft.AspNetCore.Mvc;
using Zombie.Models;
using Zombie.Provider;

namespace Zombie.Controllers;

[ApiController]
[Route("account")]
public class AuthController : ControllerBase
{
    private IAuthProvider authProvider;
    public AuthController(IAuthProvider provider)
    {
        authProvider = provider;
    }
    
    /// <summary>
    /// возвращает JWT токен
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    [HttpPost("login/")]
    public async Task<IActionResult> LoginAsync(UserData userData)
    {
        return Ok(authProvider.LoginAsync(userData));
    }
}