using Microsoft.AspNetCore.Mvc;
using MyWebApps.Data;
using MyWebApps.Models;

namespace MyWebApps.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //list of data coming from the database.
            IEnumerable<Category> categories = _context.categories;
            return View(categories); // data sending to view Category
        }
    }
}
