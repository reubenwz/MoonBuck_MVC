using Microsoft.AspNetCore.Mvc;
using MoonBuck.DataAccess.Data;
using MoonBuck.DataAccess.Repository;
using MoonBuck.DataAccess.Repository.IRepository;
using MoonBuck.Models;

namespace MoonBuck.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlotController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public SlotController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Slot> slotList = _unitOfWork.Slot.GetAll().ToList();
            return View(slotList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Slot obj)
        {
            if (obj.StartTime < obj.EndTime)
            {
                ModelState.AddModelError("StartTime", "The Start Time cannot be lesser than End Time");
            }
            if (ModelState.IsValid)
            {
                _unitOfWork.Slot.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Slot added successfully";
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
            Slot? slotFromDb = _unitOfWork.Slot.Get(u => u.Id == id);
            //Slot? roleFromDb1 = _db.Slots.FirstOrDefault(u => u.Id == id);
            //Slot? roleFromDb2 = _db.Slots.Where(u => u.Id == id).FirstOrDefault();
            if (slotFromDb == null)
            {
                return NotFound();
            }
            return View(slotFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Slot obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Slot.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Slot updated successfully";
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
            Slot? slotFromDb = _unitOfWork.Slot.Get(u => u.Id == id);
            if (slotFromDb == null)
            {
                return NotFound();
            }
            return View(slotFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Slot? obj = _unitOfWork.Slot.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Slot.Remove(obj);
            TempData["success"] = "Slot deleted successfully";
            _unitOfWork.Save();
            return RedirectToAction("Index");
        }
    }
}
