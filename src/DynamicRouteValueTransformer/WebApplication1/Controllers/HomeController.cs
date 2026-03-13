using Microsoft.AspNetCore.Mvc;
using Starwars.Jedis.Business.Interfaces;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers;

public class HomeController(IJediBusiness jediBusiness) : Controller
{
    public IActionResult Index()
    {
        var jedis = jediBusiness.List();
        return View(jedis);
    }

    public IActionResult Privacy() => View();

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
