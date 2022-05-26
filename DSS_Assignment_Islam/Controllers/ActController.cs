using DSS_Assignment_Islam.Models;
using DSS_Assignment_Islam.Repository;
using DSS_Assignment_Islam.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DSS_Assignment_Islam.Controllers
{
    public class ActController : Controller
    {

        private DBContext db;
        private readonly IAct _Act;
        private readonly ITrick _Trick;
        private readonly IActor _Actor;

        public ActController(DBContext _db, IAct _IAct, ITrick _ITrick, IActor _IActor)
        {
            db = _db;
            _Act = _IAct;
            _Trick = _ITrick;
            _Actor = _IActor;
        }

        public IActionResult Index()
        {
            return View(_Act.GetActs.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["ActorID"] = new SelectList(db.Actors, "ActorID", "ActorName");
            ViewData["TrickID"] = new SelectList(db.Tricks, "TrickID", "TrickName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Act model)
        {
            if (ModelState.IsValid)
            {
                _Act.Add(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete(int ID)
        {
            Act model = _Act.GetAct(ID);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int ID)
        {
            _Act.Remove(ID);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int ID)
        {
            var model = _Act.GetAct(ID);
            ViewData["AssassinID"] = new SelectList(db.Actors, "ActorID", "ActorName");
            ViewData["TrickID"] = new SelectList(db.Tricks, "TrickID", "TrickName");
            ViewData["ActID"] = new SelectList(db.Acts, "ActID", "ActName");
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Act model)
        {
            if (ModelState.IsValid)
            {
                db.Acts.Update(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Details(int ID)
        {
            return View(_Act.GetAct(ID));
        }


    }
}
