using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Starwars.Jedis.Business.Interfaces;
using WebApplication1.Models;
using WebApplication1.ViewModels;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IJediBusiness _jediBusiness;
        private IItemLocalizerBusiness _itemLocalizerBusiness;

        public HomeController(IJediBusiness jediBusiness,
                               IItemLocalizerBusiness itemLocalizerBusiness,
                               ILogger<HomeController> logger)
        {
            _jediBusiness = jediBusiness;
            _itemLocalizerBusiness = itemLocalizerBusiness;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var jedis = _jediBusiness.List();
            var groups = _itemLocalizerBusiness.List();

            var model = new HomeViewModel() {
                Groups= groups,
                Jedis = jedis
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
}
