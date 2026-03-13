using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Starwars.Jedis.Business.Interfaces;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers;

public class HomeController(
    IJediBusiness jediBusiness,
    IItemLocalizerBusiness itemLocalizerBusiness) : Controller
{
    public IActionResult Index()
    {
        var model = new HomeViewModel
        {
            Groups = itemLocalizerBusiness.List(),
            Jedis = jediBusiness.List()
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
