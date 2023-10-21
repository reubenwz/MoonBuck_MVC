using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MoonBuck.DataAccess.Data;
using MoonBuck.DataAccess.Repository;
using MoonBuck.DataAccess.Repository.IRepository;
using MoonBuck.Models;
using MoonBuck.Models.ViewModels;

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
            List<Slot> slotList = _unitOfWork.Slot.GetAll(includeProperties:"Role").ToList();

            return View(slotList);
        }
        public IActionResult Upsert(int? id)
        {
            SlotVM slotVM = new()
            {
                RoleList = _unitOfWork.Role
                    .GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    }),
                Slot = new Slot()
                {
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddHours(1)
                }
            };
            if (id == null || id == 0)
            {
                //create
                return View(slotVM);
            }
            else
            {
                //update
                slotVM.Slot = _unitOfWork.Slot.Get(u=>u.Id == id);
                return View(slotVM);
            }
        }
        [HttpPost]
        public IActionResult Upsert(SlotVM obj)
        {
            if (obj.Slot.StartTime > obj.Slot.EndTime)
            {
                ModelState.AddModelError("StartTime", "The Start Time cannot be more than End Time");
            }
            if (ModelState.IsValid)
            {
                if (obj.Slot.Id == 0)
                {
                    _unitOfWork.Slot.Add(obj.Slot);
                }
                else
                {
                    _unitOfWork.Slot.Update(obj.Slot);
                }
                _unitOfWork.Save();
                TempData["success"] = "Slot added successfully";
                return RedirectToAction("Index");
            }
            else
            {
                obj.RoleList = _unitOfWork.Role
                    .GetAll().Select(u => new SelectListItem
                    {
                        Text = u.Name,
                        Value = u.Id.ToString()
                    });
                return View(obj);
            }
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
