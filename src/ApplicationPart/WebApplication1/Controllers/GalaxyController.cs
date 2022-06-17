using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class GalaxyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
