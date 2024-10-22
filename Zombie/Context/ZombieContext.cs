using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Zombie.Context;

using Microsoft.EntityFrameworkCore;
using Models;



public class ZombieContext : DbContext
{
    /// <summary>
    /// Список сохранений
    /// </summary>
    public DbSet<GameData> GameDatas { get; set; } = null!;
    
    /// <summary>
    /// Устанавливаем праметры подключения к базе данных
    /// </summary>
    /// <param name="options"></param>
    public ZombieContext(DbContextOptions options) : base(options) {}
}