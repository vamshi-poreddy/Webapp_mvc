using Microsoft.AspNetCore.Mvc;
using Webapp_mvc.Models;

namespace Webapp_mvc.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = Category_Repository.GetCategories();
            return View(categories);
        }
        public IActionResult Delete(int id)
        {
            Category_Repository.DeleteCategory(id);
            var categories = Category_Repository.GetCategories();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            var category = Category_Repository.GetCategoryById(id.HasValue ? id.Value : 0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                Category_Repository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            if (ModelState.IsValid)
            {
                Category_Repository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
