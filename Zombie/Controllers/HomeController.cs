using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Zombie.Context;
using Zombie.Models;

namespace Zombie.Controllers;


public class HomeController : Controller
{
    ZombieContext db;
    
    public HomeController(ZombieContext context)
    {
        db = context;
    }
 
    public async Task<IActionResult> Index()
    {
        return View(await db.GameDatas.ToListAsync());
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(GameData data)
    {
        db.GameDatas.Add(data);
        await db.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}