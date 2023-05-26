using Microsoft.AspNetCore.Mvc;
using Book_Store.Models;
using Book_Store.Data;

namespace Book_Store.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) => _db = db;

        public IActionResult Index()
        {
            List<Category> categoryList = _db.Categories.ToList();
            return View(categoryList);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Category newCategory)
        {
            var existingName = _db.Categories.FirstOrDefault(c => c.Name == newCategory.Name);
            var existingOrder = _db.Categories.FirstOrDefault(c => c.DisplayOrder == newCategory.DisplayOrder);

            if (existingName != null)
                ModelState.AddModelError("existData", "The Name already exists.");

            if (existingOrder != null)
                ModelState.AddModelError("existData", "The Order already exists.");

            if (ModelState.IsValid)
            {
                _db.Categories.Add(newCategory);
                _db.SaveChanges();
                TempData["success"] = "Category created successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) return NotFound();

            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null) return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category editCategory)
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(editCategory);
                _db.SaveChanges();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) return NotFound();

            Category? categoryFromDb = _db.Categories.Find(id);
            if (categoryFromDb == null) return NotFound();

            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? findingCatrgory = _db.Categories.Find(id);
            if (findingCatrgory == null) return NotFound();

            _db.Categories.Remove(findingCatrgory);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
