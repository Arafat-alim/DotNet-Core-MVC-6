using Microsoft.AspNetCore.Mvc;
using MyWeb.DataAccessLayer.Infrastructure.IRepository;
using MyWeb.Models;
using MyWeb.Models.ViewModels;
using MyWebApps.Data;


namespace MyWebApps.Controllers
{
    //defining Area
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private IUnitOfWork _iunitofwork;
        //private ApplicationDbContext _context;

        //public CategoryController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        public CategoryController(IUnitOfWork unitofwork)
        {
            _iunitofwork = unitofwork;
        }

        public IActionResult Index()
        {
            //list of data coming from the database.
            //IEnumerable<Category> categories = _context.categories;
            CategoryVM categoryVm = new CategoryVM();
            //IEnumerable<Category> categories = _iunitofwork.categoryRepository.GetAll();
            categoryVm.Categories = _iunitofwork.categoryRepository.GetAll();
            return View(categoryVm); // data sending to view Category
        }
        //creating a Get Request
        //[HttpGet]
        //public IActionResult Create()
        //{
        //    return View();
        //}
        ////creating a Post Request adding
        //public IActionResult Create(Category category) //yeh category form se ayega
        //{
        //    if(ModelState.IsValid)
        //    {
        //        //_context.categories.Add(category); //Form se aya data add kar diya database

        //        _iunitofwork.categoryRepository.Add(category);

        //        //_context.SaveChanges(); //database ko save kardiya
        //        _iunitofwork.Save();
        //        TempData["success"] = "Created Data Successfully!";
        //        return RedirectToAction("Index");
        //    }
        //    return View(category);
            
        //}
        //creating a request for updating
        //creating a Get Request
        [HttpGet]
        //public IActionResult Edit(int? id) //updating the edit to create/edit method
        public IActionResult CreateUpdate(int? id)
        {
           // Category category = new Category(); //Tightly coupled
            CategoryVM vm = new CategoryVM();  // loosely coupled
            if (id == null || id == 0)
            {
                //return NotFound
                //creating the new category
                return View(vm);
            }
            else
            {
                //id nikaalenge
                // var category = _context.categories.Find(id);
                //var Editcategory = _iunitofwork.categoryRepository.GetT(x => x.Id == id);
                vm.Category = _iunitofwork.categoryRepository.GetT(x => x.Id == id);
                if (vm.Category == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(vm);
                }
            }
        }
        //creating a Post Request adding
        [HttpPost]
        public IActionResult CreateUpdate(CategoryVM vm) //yeh category form se ayega
        {
            if (ModelState.IsValid)
            {
                if(vm.Category.Id == 0)
                {
                    //_context.categories.Update(category); //Form se aya data add kar diya database
                    _iunitofwork.categoryRepository.Add(vm.Category);
                    TempData["success"] = "Data Created Successfully!";
                }
                else
                {
                    _iunitofwork.categoryRepository.Update(vm.Category);
                    TempData["success"] = "Data Edited Successfully!";
                }
                //_context.SaveChanges(); //database ko save kardiya
                _iunitofwork.Save();
              
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");

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
                //var category = _context.categories.Find(id);
                var category = _iunitofwork.categoryRepository.GetT(x => x.Id == id);
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
            //var category = _context.categories.Find(id);
            var category = _iunitofwork.categoryRepository.GetT(x => x.Id == id);
            if(category == null)
            {
                return NotFound();
            }
            //_context.categories.Remove(category);
            _iunitofwork.categoryRepository.Delete(category);
            //_context.SaveChanges();
            _iunitofwork.Save();
            TempData["success"] = "Data Delete Successfully!";
            return RedirectToAction("Index");

        }
    }
}
