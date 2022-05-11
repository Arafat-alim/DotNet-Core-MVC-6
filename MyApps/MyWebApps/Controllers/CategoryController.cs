using Microsoft.AspNetCore.Mvc;
using MyWeb.Models;
using MyWebApps.Data;


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
        //creating a Get Request
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //creating a Post Request adding
        public IActionResult Create(Category category) //yeh category form se ayega
        {
            if(ModelState.IsValid)
            {
                _context.categories.Add(category); //Form se aya data add kar diya database
                _context.SaveChanges(); //database ko save kardiya
                TempData["success"] = "Created Data Successfully!";
                return RedirectToAction("Index");
            }
            return View(category);
            
        }
        //creating a request for updating
        //creating a Get Request
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if(id ==  null || id == 0)
            {
                return NotFound();
            }
            else
            {
                //id nikaalenge
                var category = _context.categories.Find(id);
                if(category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(category);
                }                
            }
        }
        //creating a Post Request adding
        [HttpPost]
        public IActionResult Edit(Category category) //yeh category form se ayega
        {
            if (ModelState.IsValid)
            {
                _context.categories.Update(category); //Form se aya data add kar diya database
                _context.SaveChanges(); //database ko save kardiya
                TempData["success"] = "Edited Data Successfully!";
                return RedirectToAction("Index");
            }
            return View(category);

        }

        //Delete Request
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            else
            {
                //id nikaalenge
                var category = _context.categories.Find(id);
                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(category);
                }
            }
        }
        //creating a Post Request adding
        [HttpPost,ActionName("Delete")]
        public IActionResult DeleteData(int? id) //yeh category form se ayega
        {
            //category nikaalenge
            var category = _context.categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            _context.categories.Remove(category);
            _context.SaveChanges();
            TempData["success"] = "Delete Data Successfully!";
            return RedirectToAction("Index");

        }
    }
}
