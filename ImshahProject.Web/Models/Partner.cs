using System.ComponentModel.DataAnnotations;

namespace ImshahProject.Web.Models
{
    public class Partner
    {
        public int Id { get; set; }
        [Display(Name = "Name Company")]
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Display(Name = "Image Company")]
        public string? ImageUrl { get; set; }

    }
}
