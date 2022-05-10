using Microsoft.AspNetCore.Mvc;

namespace MyWebApps.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
