using System.ComponentModel.DataAnnotations;

namespace ImshahProject.Web.Models
{
    public class Quote
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Full Name is required")]
        public string? FullName { get; set; }
        [Required(ErrorMessage = "Company Name is required")]
        public string? CompanyName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string? Subject { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string? Message { get; set; }
    }
}
