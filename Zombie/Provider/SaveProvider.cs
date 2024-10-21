namespace Zombie.Provider;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Context;
using Models;



public class SaveProvider : ISaveProvider
{
    private ZombieContext db;

    public SaveProvider(ZombieContext context)
    {
        db = context;
    }
    
    /// <inheritdoc/>
    public Task<GameData?> GetData(int playerId) =>
        db.GameDatas.Where(p => p.PlayerId == playerId).OrderByDescending(p => p.Id).FirstOrDefaultAsync();
    
    
    /// <inheritdoc/>
    public async Task<IActionResult> AddData(GameData data)
    {
        try
        {
            db.GameDatas.Add(data);
            await db.SaveChangesAsync();
            return new OkResult(); 
        }
        catch (Exception ex)
        {
            return new BadRequestObjectResult($"An error occurred: {ex.Message}");
        }
    }
}

