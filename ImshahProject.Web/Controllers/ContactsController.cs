using AutoMapper;
using ImshahProject.Web.Data;
using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;
using ImshahProject.Web.Utlity;
using ImshahProject.Web.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;


namespace ImshahProject.Web.Controllers
{
    [Authorize(Roles = $"{SD.Role_Customer},{SD.Role_Admin}")]
    public class ContactsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ImshahProjectContext _db;
        public ContactsController(IUnitOfWork unitOfWork,IMapper mapper, ImshahProjectContext db)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _db = db;
        }
        public IActionResult Index() => 
              View(_mapper.Map<List<ContactsVM>>(_unitOfWork.contacts.GetAll()));
        
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }
        public async Task Send(string fromUser,string fullName, string subject, string body)
        {
            // create message
            var message = new MailMessage();

            message.From = new MailAddress(fromUser);
            message.Subject = subject;
            message.Body = " Name : " + fullName + "\n"+ " Email : " + fromUser + "\n\n" + " Message : " + body;
            message.To.Add(new MailAddress("info@imshah.com", "Content Management System"));
            message.IsBodyHtml = false;
            try
            {
                var emailClient = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,

                    Credentials = new NetworkCredential("info@imshah.com", "poplsrexntdcusal")
                };

                await emailClient.SendMailAsync(message);
            }
            catch (Exception ex)
            {

            }
            // send email

        }
    
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Contact contact)
        {
            if (ModelState.IsValid)
            {
                Send( contact.Email,contact.FullName,contact!.Subject,contact.Message);
                _unitOfWork.contacts.Add(contact);
                _unitOfWork.Save();
                TempData["success"] = "Add Information Contact is successfully";
                return RedirectToAction("Index", "Home");
            }
            TempData["error"] = "Add Information Contact is Failed !!";
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var contactsId = _unitOfWork.contacts.GetFirstOrDeafult(u => u.Id == id);
            if (contactsId == null)
            {
                return NotFound();
            }
            return View(contactsId);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var contacts = _unitOfWork.contacts.GetFirstOrDeafult(u => u.Id == id);
            if (contacts == null)
            {
                return NotFound();
            }
            _unitOfWork.contacts.Remove(contacts);
            _unitOfWork.Save();
            TempData["success"] = "Delete contact is successfully";
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteContacts(List<ContactsVM> con)
        {
            List<Contact> contacts = new List<Contact>();
            foreach (var item in con)
            {
                if (item.Con!.Selected)
                {
                    var selectedContacts = _db.Contacts.Find(item.Id);
                    contacts.Add(selectedContacts!);
                }
            }
            _db.Contacts.RemoveRange(contacts);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allContacts = _unitOfWork.contacts.GetAll();
            return Json(new { data = allContacts });
        }

        [HttpDelete]
        public IActionResult DeleteItem(int? id)
        {
            var contact = _unitOfWork.contacts.GetFirstOrDeafult(u => u.Id == id);
            if (contact == null)
            {
                return Json(new { success = false, message = "Error While deleting" });
            }
            _unitOfWork.contacts.Remove(contact);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful !" });
        }
        #endregion
    }
}
