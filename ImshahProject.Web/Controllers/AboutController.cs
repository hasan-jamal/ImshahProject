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
    public class AboutController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AboutController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            IEnumerable<About> objectAboutsList = _unitOfWork.abouts.GetAll();

            return View(objectAboutsList);
        }
        public IActionResult Upsert(int? id)
        {
            AboutVM aboutVM = new()
            {
                About = new()
            };
            if (id == 0 || id == null)
            {
                return View(aboutVM);

            }
            else
            {
                //Update Service
                aboutVM.About = _unitOfWork.abouts.GetFirstOrDeafult(u => u.Id == id);
                return View(aboutVM);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(AboutVM aboutVM, IFormFile? file, IFormFile? file2)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null && file2 != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    string fileName2 = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Components\Images\Abouts");
                    var extension = Path.GetExtension(file.FileName);
                    var extension2 = Path.GetExtension(file2.FileName);
                    if (aboutVM.About.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, aboutVM.About.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName2 + extension2), FileMode.Create))
                    {
                        file2.CopyTo(fileStream);
                    }
                    aboutVM.About.ImageUrl = @"\Components\Images\Abouts\" + fileName + extension;
                    aboutVM.About.ImageUrl2 = @"\Components\Images\Abouts\" + fileName2 + extension2;

                }
                if (aboutVM.About.Id == 0)
                {
                    _unitOfWork.abouts.Add(aboutVM.About);
                    TempData["success"] = " Create About Data is successfully";
                }
                else
                {
                    _unitOfWork.abouts.Update(aboutVM.About);
                    TempData["success"] = " Update About Data is successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(aboutVM);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var aboutsId = _unitOfWork.abouts.GetFirstOrDeafult(u => u.Id == id);
            if (aboutsId == null)
            {
                return NotFound();
            }
            return View(aboutsId);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var abouts = _unitOfWork.abouts.GetFirstOrDeafult(u => u.Id == id);
            if (abouts == null)
            {
                return NotFound();
            }
            _unitOfWork.abouts.Remove(abouts);
            _unitOfWork.Save();
            TempData["success"] = "Delete About is successfully";
            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allAbouts= _unitOfWork.abouts.GetAll();
            return Json(new { data = allAbouts });
        }

        [HttpDelete]
        public IActionResult DeleteItem(int? id)
        {
            var about = _unitOfWork.abouts.GetFirstOrDeafult(u => u.Id == id);
            if (about == null)
            {
                return Json(new { success = false, message = "Error While deleting" });
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, about.ImageUrl.TrimStart('\\'));
            var oldImagePath1 = Path.Combine(_webHostEnvironment.WebRootPath, about.ImageUrl2.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            if (System.IO.File.Exists(oldImagePath1))
            {
                System.IO.File.Delete(oldImagePath1);
            }
            _unitOfWork.abouts.Remove(about);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful !" });
        }
        #endregion
    }
}