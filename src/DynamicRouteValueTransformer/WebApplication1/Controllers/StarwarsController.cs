using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Starwars.Jedis.Business.Interfaces;

namespace WebApplication1.Controllers
{
    public class StarwarsController : Controller
    {
        private IJediBusiness _jediBusiness;

        public StarwarsController(IJediBusiness jediBusiness)
        {
            _jediBusiness = jediBusiness;
        }

        public IActionResult JediDetails(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            var jedi = _jediBusiness.GetById(id);

            return View(jedi);
        }

        public IActionResult JediNotFound()
        {
            return View();
        }
    }
}
