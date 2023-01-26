using System.ComponentModel.DataAnnotations;

namespace ImshahProject.Web.Models
{
    public class Information
    {
        public int Id { get; set; }
        [Display(Name = "Email Address")]
        public string? Email { get; set; }
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }
        [Display(Name = "Find Us")]
        public string? FindUs { get; set; }
        [Display(Name = "Find Us Arabic")]
        public string? FindUs_ar { get; set; }
        [Display(Name = "Facebook Link")]
        public string? Facebook { get; set; }
        [Display(Name = "Twiter Link")]
        public string? Twiter { get; set; }

        [Display(Name = "Get Aquote")]
        public string? GetAquote { get; set; }

        [Display(Name = "Get Aquote Arabic")]
        public string? GetAquote_ar { get; set; }

        [Display(Name = "Working hours")]
        public string? Workinghours { get; set; }

    }
}
