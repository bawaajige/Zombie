namespace Zombie.Controllers;

using Microsoft.AspNetCore.Mvc;
using Provider;

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
    [HttpGet("login/{username}")]
    public async Task<IActionResult> Login(string username)
    {
        return Ok(authProvider.Login(username));
    }
}