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
    /// </summary>
    /// <param name="userData"></param>
    /// <returns>jwt токен</returns>
    [HttpGet("login")]
    public async Task<IActionResult> LoginAsync(UserData userData)
    {
        var login = await authProvider.Login(userData);
        return Ok(login);
    }
    
    /// <summary>
    /// </summary>
    /// <param name="username"></param>
    /// <returns>JWT токен</returns>
    [HttpPost("register/")]
    public async Task<IActionResult> RegisterAsync(UserData userData)
    {
        var register = await authProvider.Register(userData);
        return Ok(register);
    }
}