using Microsoft.AspNetCore.Mvc;

namespace MVC.Controllers
{
    public class OrnekController : Controller
    {
        public IActionResult Index()
        {
            return View("OrnekView");
        }
    }
}
