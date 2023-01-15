using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;
using BulkyBookWeb.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CoverTypeController : Controller
    {
        
        private readonly IUnitOfWork db;
        public CoverTypeController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<CoverType> cover = db.CoverType.GetAll();
            return View(cover);
        }

        //Get Create
        public IActionResult Create()
        {
            return View();
        }

        //Post Create
        //There's no need to create a new variable to pass it on LinQ
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType coverType)
        {
            db.CoverType.Add(coverType);
            db.Save();
            return RedirectToAction("Index");
        }

        //Get Edit
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var cover = db.CoverType.GetFirstOrDefault(u => u.id == id);

            return View(cover);
        }

        //Post Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType coverType)
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
