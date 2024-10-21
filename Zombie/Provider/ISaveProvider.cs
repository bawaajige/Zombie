using Microsoft.AspNetCore.Mvc;
using Zombie.Models;

namespace Zombie.Provider;

public interface ISaveProvider
{
    /// <summary>
    /// Записывает данные в бд
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    Task<IActionResult> AddData(GameData data);
    
    /// <summary>
    /// Возвращает данные из бд
    /// </summary>
    /// <param name="playerId"></param>
    /// <returns></returns>
    Task<GameData?> GetData(int playerId);
}