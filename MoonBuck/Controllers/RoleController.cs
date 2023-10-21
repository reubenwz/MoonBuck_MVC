using Microsoft.AspNetCore.Mvc;
using MoonBuck.DataAccess.Data;
using MoonBuck.Models;

namespace MoonBuck.Controllers
{
    public class RoleController : Controller
    {
        private readonly ApplicationDbContext _db;
        public RoleController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Role> roleList = _db.Roles.ToList();
            return View(roleList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Role obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The Name and Display Order cannot be the same");
            }
            if (ModelState.IsValid)
            {
                _db.Roles.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Role added successfully";
                return RedirectToAction("Index");
            }
            return View();  
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Role? roleFromDb = _db.Roles.Find(id);
            //Role? roleFromDb1 = _db.Roles.FirstOrDefault(u => u.Id == id);
            //Role? roleFromDb2 = _db.Roles.Where(u => u.Id == id).FirstOrDefault();
            if (roleFromDb == null)
            {
                return NotFound();
            }
            return View(roleFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Role obj)
        {
            if (ModelState.IsValid)
            {
                _db.Roles.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Role updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Role? roleFromDb = _db.Roles.Find(id);
            if (roleFromDb == null)
            {
                return NotFound();
            }
            return View(roleFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Role? obj = _db.Roles.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Roles.Remove(obj);
            TempData["success"] = "Role deleted successfully";
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
