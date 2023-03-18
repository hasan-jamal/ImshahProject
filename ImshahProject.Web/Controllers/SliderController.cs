using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;
using ImshahProject.Web.Utlity;
using ImshahProject.Web.ViewModels;
using System.Data;

namespace ImshahProject.Web.Controllers
{
    [Authorize(Roles = $"{SD.Role_Customer},{SD.Role_Admin}")]
    public class SliderController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SliderController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {

            IEnumerable<Slider> objectSlidersList = _unitOfWork.sliders.GetAll();

            return View(objectSlidersList);
        }
        public IActionResult Upsert(int? id)
        {
            SliderVM sliderVM = new()
            {
                Slider = new()
            };
            if (id == 0 || id == null)
            {
                return View(sliderVM);

            }
            else
            {
                //Update Service
                sliderVM.Slider = _unitOfWork.sliders.GetFirstOrDeafult(u => u.Id == id);
                return View(sliderVM);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(SliderVM sliderVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Components\Images\Sliders");
                    if (!Directory.Exists(Path.Combine(uploads)))
                         Directory.CreateDirectory(Path.Combine(uploads));
                            
                    var extension = Path.GetExtension(file.FileName);
                    if (sliderVM.Slider.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, sliderVM.Slider.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    sliderVM.Slider.ImageUrl = fileName + extension;
                }
                if (sliderVM.Slider.Id == 0)
                {
                    _unitOfWork.sliders.Add(sliderVM.Slider);
                    TempData["success"] = " Create Slider is successfully";
                }
                else
                {
                    _unitOfWork.sliders.Update(sliderVM.Slider);
                    TempData["success"] = " Update Slider is successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(sliderVM);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var slidersId = _unitOfWork.sliders.GetFirstOrDeafult(u => u.Id == id);
            if (slidersId == null)
            {
                return NotFound();
            }
            return View(slidersId);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var sliders = _unitOfWork.sliders.GetFirstOrDeafult(u => u.Id == id);
            if (sliders == null)
            {
                return NotFound();
            }
            _unitOfWork.sliders.Remove(sliders);
            _unitOfWork.Save();
            TempData["success"] = "Delete Slider is successfully";
            return RedirectToAction("Index");
        }




        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allSliders= _unitOfWork.sliders.GetAll();
            return Json(new { data = allSliders });
        }

        [HttpDelete]
        public IActionResult DeleteItem(int? id)
        {
            var slider = _unitOfWork.sliders.GetFirstOrDeafult(u => u.Id == id);
            if (slider == null)
            {
                return Json(new { success = false, message = "Error While deleting" });
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, slider.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.sliders.Remove(slider);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful !" });
        }
        #endregion
    }
}