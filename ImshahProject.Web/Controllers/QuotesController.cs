using AutoMapper;
using ImshahProject.Web.DataAccess.IRepository;
using ImshahProject.Web.Models;
using ImshahProject.Web.Utlity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;


namespace ImshahProject.Web.Controllers
{
    [Authorize(Roles = $"{SD.Role_Customer},{SD.Role_Admin}")]
    public class QuotesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public QuotesController(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            IEnumerable<Quote> objectQuotesList = _unitOfWork.quotes.GetAll();
            return View(objectQuotesList);
        }
        [AllowAnonymous]
        public IActionResult Create()
        {
            return View();
        }
        public async Task Send(string fromUser,string companyName,string fullName, string subject, string body)
        {
            // create message
            var message = new MailMessage();

            message.From = new MailAddress(fromUser);
            message.Subject = subject;
            message.Body = " Name : " + fullName + "\n" + " Company Name : " + companyName + "\n"+ " Email : " + fromUser + "\n\n" + " Message : " + body;
            message.To.Add(new MailAddress("hasanjamalabusharekh@gmail.com", "Content Management System"));
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
                    Credentials = new NetworkCredential("hasanjamalabusharekh@gmail.com", "wfgvqslcryeecutt")
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
        public IActionResult Create(Quote quote)
        {
            if (ModelState.IsValid)
            {
                Send(quote.Email, quote.CompanyName, quote.FullName, quote.Subject, quote.Message);
                _unitOfWork.quotes.Add(quote);
                _unitOfWork.Save();
                TempData["success"] = "Add Information Quote is successfully";
                return RedirectToAction("Index", "Home");
            }
            TempData["error"] = "Add Information Quote is Failed !!";
            return View();
        }


        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 && id == null)
            {
                return NotFound();
            }
            var QuotesId = _unitOfWork.quotes.GetFirstOrDeafult(u => u.Id == id);
            if (QuotesId == null)
            {
                return NotFound();
            }
            return View(QuotesId);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var quotes = _unitOfWork.quotes.GetFirstOrDeafult(u => u.Id == id);
            if (quotes == null)
            {
                return NotFound();
            }
            _unitOfWork.quotes.Remove(quotes);
            _unitOfWork.Save();
            TempData["success"] = "Delete Quote is successfully";
            return RedirectToAction("Index");
        }

        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var allQuotes = _unitOfWork.quotes.GetAll();
            return Json(new { data = allQuotes });
        }

        [HttpDelete]
        [AllowAnonymous]
        public IActionResult DeleteItem(int? id)
        {
            var Quote = _unitOfWork.quotes.GetFirstOrDeafult(u => u.Id == id);
            if (Quote == null)
            {
                return Json(new { success = false, message = "Error While deleting" });
            }
            _unitOfWork.quotes.Remove(Quote);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful !" });
        }
        #endregion
    }
}
