using Book_Store.Data;
using Book_Store.Models;
using Microsoft.AspNetCore.Mvc;

namespace Book_Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category newCategory)
        {
            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult Delete()
        {
            _db.Remove(_db.Categories.Last());
            _db.SaveChanges();
            return RedirectToAction("Category");
        }
    }
}
