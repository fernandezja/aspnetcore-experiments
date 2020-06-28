using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Starwars.Jedis.Business.Interfaces;
using Starwars.Jedis.Entities;

namespace WebApplication1.Controllers
{
    public class StarwarsController : Controller
    {
        private IJediBusiness _jediBusiness;
        private IItemLocalizerBusiness _itemLocalizerBusiness;

        public StarwarsController(IJediBusiness jediBusiness,
                                  IItemLocalizerBusiness itemLocalizerBusiness)
        {
            _jediBusiness = jediBusiness;
            _itemLocalizerBusiness = itemLocalizerBusiness;
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

        public IActionResult GroupNotFound()
        {
            return View();
        }

        public IActionResult GroupDetails(string language, string itemKey, int jediId)
        {
            if (string.IsNullOrEmpty(language))
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(itemKey))
            {
                return BadRequest();
            }

            if (jediId <= 0)
            {
                return BadRequest();
            }

            var itemLocalizable = _itemLocalizerBusiness.GetByKey(language, itemKey);
            var jedi = _jediBusiness.GetById(jediId);

            var group = new Group() {
                ItemLocalizable = itemLocalizable,
                Jedi = jedi
            };

            return View(group);
        }
    }
}
