using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Zombie.Models;
using Zombie.Context;


namespace Zombie.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class SaveController : Controller
    {
        private ZombieContext db;

        public SaveController(ZombieContext context)
        {
            db = context;
        }
        
        [HttpGet]
        public IActionResult GetData()
        {
            var datas = db.GameDatas.OrderByDescending(d => d.Id).FirstOrDefault();
            return Ok(JsonConvert.SerializeObject(datas));
        }
        
        
        [HttpPost]
        public async Task<IActionResult> AddData()
        {
            try
            {
                using (StreamReader reader = new StreamReader(Request.Body))
                {
                    string json = await reader.ReadToEndAsync();
                    var data = JsonConvert.DeserializeObject<GameData>(json);
    
                    db.GameDatas.Add(data);
                    await db.SaveChangesAsync();
    
                    return Ok("Data added successfully");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}