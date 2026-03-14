using Microsoft.AspNetCore.Mvc;
using Starwars.Jedis.Business.Interfaces;
using Starwars.Jedis.Entities;

namespace WebApplication1.Controllers;

public class StarwarsController(
    IJediBusiness jediBusiness,
    IItemLocalizerBusiness itemLocalizerBusiness) : Controller
{
    public IActionResult JediDetails(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }

        var jedi = jediBusiness.GetById(id);
        if (jedi is null)
        {
            return View(nameof(JediNotFound));
        }

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
        if (string.IsNullOrWhiteSpace(language))
        {
            return BadRequest();
        }

        if (string.IsNullOrWhiteSpace(itemKey))
        {
            return BadRequest();
        }

        if (jediId <= 0)
        {
            return BadRequest();
        }

        var itemLocalizable = itemLocalizerBusiness.GetByKey(language, itemKey);
        if (itemLocalizable is null)
        {
            return View(nameof(GroupNotFound));
        }

        var jedi = jediBusiness.GetById(jediId);
        if (jedi is null)
        {
            return View(nameof(JediNotFound));
        }

        var group = new Group
        {
            ItemLocalizable = itemLocalizable,
            Jedi = jedi
        };

        return View(group);
    }
}
