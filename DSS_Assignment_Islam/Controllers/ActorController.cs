using DSS_Assignment_Islam.Models;
using DSS_Assignment_Islam.Repository;
using DSS_Assignment_Islam.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSS_Assignment_Islam.Controllers
{
    public class ActorController : Controller
    {
        private readonly IActor _Actor;
        private readonly ICircus _Circus;
        private DBContext db;

        public ActorController(IActor _IActor, ICircus _ICircus, DBContext _db)
        {
            _Actor = _IActor;
            _Circus = _ICircus;
            db = _db;
        }

        public IActionResult Index()
        {
            var model = _Actor.GetActors;
            return View(model.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["CircusID"] = new SelectList(db.Circuses, "CircusID", "CircusName"); 
            return View();
        }

        [HttpPost]
        public IActionResult Create(Actor model)
        {
            if (ModelState.IsValid)
            {
                _Actor.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Delete(int ID)
        {
            Actor model = _Actor.GetActor(ID);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
            _Actor.Remove(ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Details(int ID)
        {
            return View(_Actor.GetActor(ID));
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            ViewData["CircusID"] = new SelectList(db.Circuses, "CircusID", "CircusName");
            var model = _Actor.GetActor(ID);
            return View("Edit", model);
        }

        [HttpPost]
        public IActionResult Edit(Actor model)
        {
            if (ModelState.IsValid)
            {
                db.Actors.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
