using Microsoft.AspNetCore.Mvc;

namespace Zombie.Provider;

public interface IAuthProvider
{
    IActionResult Login(string username);
}