using Microsoft.EntityFrameworkCore;
using Zombie.Models;

namespace Zombie.Context;

public class ZombieContext : DbContext
{
    public DbSet<GameData> GameDatas { get; set; } = null!;

    public ZombieContext(DbContextOptions<ZombieContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
}