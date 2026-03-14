using Microsoft.AspNetCore.Mvc;
using Starwars.Jedis.Business.Interfaces;

namespace WebApplication1.Controllers;

public class StarwarsController(IJediBusiness jediBusiness) : Controller
{
    public IActionResult JediDetails(int id)
    {
        if (id <= 0)
            return BadRequest();

        var jedi = jediBusiness.GetById(id);

        return View(jedi);
    }

    public IActionResult JediNotFound() => View();
}
