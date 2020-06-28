using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Starwars.Jedis.Business.Interfaces;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IJediBusiness _jediBusiness;

        public HomeController(IJediBusiness jediBusiness,
                               ILogger<HomeController> logger)
        {
            _jediBusiness = jediBusiness;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var jedis = _jediBusiness.List();

            return View(jedis);
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
}
