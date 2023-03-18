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
    public class PartnerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PartnerController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {

            IEnumerable<Partner> objectPartnersList = _unitOfWork.partners.GetAll();
            return View(objectPartnersList);
        }
        public IActionResult Upsert(int? id)
        {
            PartnersVM partnerVM = new()
            {
                Partner = new()
            };
            if (id == 0 || id == null)
            {
                return View(partnerVM);

            }
            else
            {
                //Update Service
                partnerVM.Partner = _unitOfWork.partners.GetFirstOrDeafult(u => u.Id == id);
                return View(partnerVM);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(PartnersVM partnerVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"Components\Images\Partners");
                    var extension = Path.GetExtension(file.FileName);
                    if (partnerVM.Partner.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, partnerVM.Partner.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    partnerVM.Partner.ImageUrl =  fileName + extension;
                }
                if (partnerVM.Partner.Id == 0)
                {
                    _unitOfWork.partners.Add(partnerVM.Partner);
                    TempData["success"] = " Create Partner is successfully";
                }
                else
                {
                    _unitOfWork.partners.Update(partnerVM.Partner);
                    TempData["success"] = " Update Partner is successfully";
                }
                _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            return View(partnerVM);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var partnerId = _unitOfWork.partners.GetFirstOrDeafult(u => u.Id == id);
            if (partnerId == null)
            {
                return NotFound();
            }
            return View(partnerId);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public IActionResult DeletePost(int? id)
        {
            var partners = _unitOfWork.partners.GetFirstOrDeafult(u => u.Id == id);
            if (partners == null)
            {
                return NotFound();
            }
            _unitOfWork.partners.Remove(partners);
            _unitOfWork.Save();
            TempData["success"] = "Delete Partner is successfully";
            return RedirectToAction("Index");
        }




        #region API CALLS
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            var allPartners = _unitOfWork.partners.GetAll();
            return Json(new { data = allPartners });
        }

        [HttpDelete]
        public IActionResult DeleteItem(int? id)
        {
            var partner = _unitOfWork.partners.GetFirstOrDeafult(u => u.Id == id);
            if (partner == null)
            {
                return Json(new { success = false, message = "Error While deleting" });
            }
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, partner.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _unitOfWork.partners.Remove(partner);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful !" });
        }
        #endregion
    }
}