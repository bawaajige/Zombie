using Microsoft.AspNetCore.Identity;

namespace Zombie.Models;



public class UserData 
{
    /// <summary>
    /// id
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    /// username пользователя
    /// </summary>
    public string Username { get; set; }
    
    /// <summary>
    /// пароль пользователя
    /// </summary>
    public string Password { get; set; }
}