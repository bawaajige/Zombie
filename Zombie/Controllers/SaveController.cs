namespace Zombie.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Models;
using Context;



[ApiController]
[Route("Save")]
public class SaveController : Controller
{
    private ZombieContext db;
    
    public SaveController(ZombieContext context)
    {
        db = context;
    }
    
    /*/// <summary>
    /// Обработка Get Request, фильтрация Id и поиск последней записи в бд
    /// </summary>
    /// <param name="playerId"></param>
    /// <returns>Объект модели GameData</returns>
    [HttpGet("GetData/{playerId}")]
    public Task<GameData?> GetData(int playerId) =>
        db.GameDatas.Where(p => p.PlayerId == playerId).OrderByDescending(p => p.Id).FirstOrDefaultAsync();*/
    
    /// <summary>
    /// Записывает данные в бд
    /// </summary>
    /// <param name="data"></param>
    /// <returns></returns>
    [HttpPost("AddData")]
    public async Task<IActionResult> AddData([FromBody] GameData data)
    {
        try
        {
            db.GameDatas.Add(data);
            await db.SaveChangesAsync();

            return Ok("Data added successfully");
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occurred: {ex.Message}");
        }
    }
}