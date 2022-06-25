using Microsoft.AspNetCore.Mvc;
using WebApplication5.Data;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class PasienController : Controller
    {
        private readonly AppDBContext _db;

        public PasienController(AppDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Pasien> objPasienList = _db.Pasiens;
            return View(objPasienList);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pasien obj)
        {
            if (obj.Nama == obj.Umur.ToString())
            {
                ModelState.AddModelError("CustomError", "String can't be input numeric");
            }
            if (ModelState.IsValid)
            {
                _db.Pasiens.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit(int? id)
        {
            if(id== null || id == 0)
            {
                return NotFound();  
            }
            var pasiensdromDb = _db.Pasiens.Find(id);
            
            if (pasiensdromDb == null)
            {
                return NotFound();
            }
            return View(pasiensdromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pasien obj)
        {
            if (obj.Nama == obj.Umur.ToString())
            {
                ModelState.AddModelError("CustomError", "String can't be input numeric");
            }
            if (ModelState.IsValid)
            {
                _db.Pasiens.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var pasiensdromDb = _db.Pasiens.Find(id);

            if (pasiensdromDb == null)
            {
                return NotFound();
            }
            return View(pasiensdromDb);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Pasiens.Find(id); 
            if (obj== null)
            {
                return NotFound();
            }

            _db.Pasiens.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
