using Microsoft.EntityFrameworkCore;
using Zombie.Models;

namespace Zombie.Context;

public class ZombieContext : DbContext
{
    /// <summary>
    /// Список сохранений
    /// </summary>
    public DbSet<GameData> GameDatas { get; set; } = null!;
    
    /// <summary>
    /// Список пользователей и 
    /// </summary>
    public DbSet<UserData> UserDatas { get; set; } = null!;
    
    /// <summary>
    /// Устанавливаем праметры подключения к базе данных
    /// </summary>
    /// <param name="options"></param>
    public ZombieContext(DbContextOptions options) : base(options) {}
}