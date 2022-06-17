using Microsoft.AspNetCore.Mvc;

namespace SharedComponents.Controllers
{
    public class JediController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
