using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Zombie.Context;

/// <summary>
/// Migration helper
/// </summary>
public class ZombieContextFactory :  IDesignTimeDbContextFactory<ZombieContext>
{
    
    public ZombieContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ZombieContext>();
 
        // получаем конфигурацию из файла appsettings.json
        ConfigurationBuilder builder = new ConfigurationBuilder();
        builder.SetBasePath(Directory.GetCurrentDirectory());
        builder.AddJsonFile("appsettings.json");
        IConfigurationRoot config = builder.Build();
 
        // получаем строку подключения из файла appsettings.json
        string connectionString = config.GetConnectionString("DefaultConnection");
        optionsBuilder.UseNpgsql(connectionString);
        return new ZombieContext(optionsBuilder.Options);
    }
}