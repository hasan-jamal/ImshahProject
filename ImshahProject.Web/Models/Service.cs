using System.ComponentModel.DataAnnotations;

namespace ImshahProject.Web.Models
{
    public class Service
    {
        public int Id { get; set; }
 
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Display(Name = "Name Arabic")]
        [Required(ErrorMessage = "Name Arabic is required")]
        public string? Name_ar { get; set; }
        public string? ImageUrl { get; set; }
    }
}
