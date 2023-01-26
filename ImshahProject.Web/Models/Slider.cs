using System.ComponentModel.DataAnnotations;

namespace ImshahProject.Web.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Display(Name = "Name Arabic")]
        [Required(ErrorMessage = "Name Arabic is required")]
        public string? Name_ar { get; set; }

        [Display(Name = "Text")]
        [Required(ErrorMessage = "Text is required")]
        public string? Text { get; set; }
        [Display(Name = "Text Arabic")]
        [Required(ErrorMessage = "Text Arabic is required")]
        public string? Text_ar { get; set; }
        [Display(Name = "Link Image")]
        [Required(ErrorMessage = "Link Image is required")]
        public string? ImageUrl { get; set; }
    }
}
