using DSS_Assignment_Islam.Models;
using DSS_Assignment_Islam.Repository;
using DSS_Assignment_Islam.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSS_Assignment_Islam.Controllers
{
    public class TrickController : Controller
    {
        private DBContext db;
        private readonly ITrick Trick;
        public TrickController(DBContext _db, ITrick _Tricks)
        {
            db = _db;
            Trick = _Tricks;
        }

        public IActionResult Index()
        {
            var model = Trick.GetTricks;
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Trick model)
        {
            if (ModelState.IsValid)
            {
                Trick.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int ID)
        {
            return View(Trick.GetTrick(ID));
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var model = Trick.GetTrick(ID);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Trick model)
        {
            if (ModelState.IsValid)
            {
                db.Tricks.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            var model = Trick.GetTrick(ID);
            return View("Delete", model);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
            Trick.Remove(ID);
            return RedirectToAction("Index");
        }
    }
}
