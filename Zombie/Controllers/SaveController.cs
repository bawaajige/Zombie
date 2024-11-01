using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Zombie.Context;
using Zombie.Models;
using Zombie.Provider;

namespace Zombie.Controllers;

[ApiController]
[Route("Save")]
public class SaveController : Controller
{
    private ZombieContext db;
    private ISaveProvider saveProvider;

    public SaveController(ZombieContext context, ISaveProvider provider)
    {
        db = context;
        saveProvider = provider;
    }

    /// <summary>
    /// Обработка Get Request, фильтрация Id и поиск последней записи в бд, только для авторизованных
    /// </summary>
    /// <param name="playerId"></param>
    /// <returns>Объект модели GameData</returns>
    //[Authorize]
    [HttpGet("GetData/{playerId}")]
    public async Task<GameData> GetData(int playerId)
    {
        GameData? data = await saveProvider.GetData(playerId);
        return data;
    }

    /// <summary>
    /// Записывает данные в бд, только для авторизованных
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    [Authorize]
    [HttpPost("AddData")]
    public async Task<IActionResult> AddData(GameData data)
    {
        try
        {
            saveProvider.AddData(data);
            return Ok("Data added successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
}