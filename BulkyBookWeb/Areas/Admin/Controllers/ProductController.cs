using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        
        private readonly IUnitOfWork db;
        public ProductController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> products = db.Product.GetAll();
            return View(products);
        }

        //Get Edit
        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Product product = new();
            IEnumerable<SelectListItem> CategoryList = db.Category.GetAll().Select(
                u=>new SelectListItem
                {
                    Text=u.Name,
                    Value=u.id.ToString()
                }
            );
            IEnumerable<SelectListItem> CoveTypeList = db.CoverType.GetAll().Select(
                u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.id.ToString()
                }
            );
            if (id == null || id == 0)
            {
                //create product
                ViewBag.CategoryList=CategoryList;
                return View(product);
            }
            else
            {
                //update product


            }

            return View();
        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(CoverType coverType)
        {
            db.CoverType.Update(coverType);
            db.Save();
            return RedirectToAction("Index");
        }

        //Get Delete
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var DeleteCover = db.CoverType.GetFirstOrDefault(u => u.id == id);

            return View(DeleteCover);
        }

        //Post Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var cover = db.CoverType.GetFirstOrDefault(u => u.id == id);
            db.CoverType.Remove(cover);
            db.Save();
            return RedirectToAction("Index");
        }

    }
}
