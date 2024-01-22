using Microsoft.AspNetCore.Mvc;

namespace MarialaTemplate.Areas.MarialaAdmin.Controllers
{
    [Area("MarialaAdmin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
