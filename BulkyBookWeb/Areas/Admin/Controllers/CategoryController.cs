using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BulkyBookWeb.DataAccess;
using BulkyBook.Models;
using BulkyBook.DataAccess.Repository.IRepository;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork db;

        public CategoryController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> cat = db.Category.GetAll();
            return View(cat);
        }
        //get

        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult AddCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Category.Add(category);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(category);

        }

        //get

        public IActionResult EditCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = db.Category.GetFirstOrDefault(u => u.id == id);

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Category.Update(category);
                db.Save();
                return RedirectToAction("Index");
            }
            return View(category);

        }

        public IActionResult DeleteCategory(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var category = db.Category.GetFirstOrDefault(u => u.id == id);

            return View(category);
        }

        [HttpPost,ActionName("DeleteCategory")]
        [ValidateAntiForgeryToken]

        public IActionResult DeleteCategoryPost(int? id)
        {
            var category = db.Category.GetFirstOrDefault(u => u.id == id);


            db.Category.Remove(category);
            db.Save();
            return RedirectToAction("Index");

        }

    }
}
