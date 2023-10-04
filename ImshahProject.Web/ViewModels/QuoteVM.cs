using ImshahProject.Web.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace ImshahProject.Web.ViewModels
{
    public class QuoteVM
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
        public SelectListItem? Con { get; set; }

    }
}
