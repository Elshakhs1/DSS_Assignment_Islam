using DSS_Assignment_Islam.Models;
using DSS_Assignment_Islam.Repository;
using DSS_Assignment_Islam.Services;
using Microsoft.AspNetCore.Mvc;

namespace DSS_Assignment_Islam.Controllers
{
    public class CircusController : Controller
    {
        private DBContext db;
        private readonly ICircus Circuses;
        public CircusController(DBContext _db, ICircus _Circuses)
        {
            db = _db;
            Circuses = _Circuses;
        }

        public IActionResult Index()
        {
            var model = Circuses.GetCircuses;
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Circus model)
        {
            if (ModelState.IsValid)
            {
                Circuses.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int ID)
        {
            return View(Circuses.GetCircus(ID));
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var model = Circuses.GetCircus(ID);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Circus model)
        {
            if (ModelState.IsValid)
            {
                db.Circuses.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            var model = Circuses.GetCircus(ID);
            return View("Delete", model);

        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
            Circuses.Remove(ID);
            return RedirectToAction("Index");
        }
    }
}
