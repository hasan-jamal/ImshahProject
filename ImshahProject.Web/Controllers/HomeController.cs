using ImshahProject.Web.Data;
using ImshahProject.Web.Models;
using ImshahProject.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ImshahProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ImshahProjectContext _db;
        public HomeController(ILogger<HomeController> logger, ImshahProjectContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var tables = new TablesVM
            {
                Services = _db.Services.ToList(),
                Sliders = _db.Sliders.ToList(),
                Goals = _db.Goals.ToList(),
                About = _db.Abouts.ToList(),
                Information = _db.Informations.ToList(),
                Partner = _db.Partners.ToList()

            };
            return View(tables);
        }
        public IActionResult Index_ar()
        {
            var tables = new TablesVM
            {
                Services = _db.Services.ToList(),
                Sliders = _db.Sliders.ToList(),
                Goals = _db.Goals.ToList(),
                About = _db.Abouts.ToList(),
                Information = _db.Informations.ToList(),
                Partner = _db.Partners.ToList()
            };
            return View(tables);
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}