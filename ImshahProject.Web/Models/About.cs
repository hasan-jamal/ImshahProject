using System.ComponentModel.DataAnnotations;

namespace ImshahProject.Web.Models
{
    public class About
    {
        public int Id { get; set; }

        [Display(Name = "Who we are")]
        [Required(ErrorMessage = "Who we are is required")]
        public string? Text1 { get; set; }
        [Display(Name = "Mission")]
        [Required(ErrorMessage = "Mission is required")]
        public string? Text2 { get; set; }

        [Display(Name = "Vision")]
        [Required(ErrorMessage = "Vision is required")]
        public string? Text3 { get; set; }

        [Display(Name = "Who we are Arabic")]
        [Required(ErrorMessage = "Who we are Arabic is required")]
        public string? Text_ar1 { get; set; }

        [Display(Name = "Mission Arabic")]
        [Required(ErrorMessage = "Mission Arabic is required")]
        public string? Text_ar2 { get; set; }

        [Display(Name = "Vision Arabic")]
        [Required(ErrorMessage = "Vision Arabic is required")]
        public string? Text_ar3 { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageUrl2 { get; set; }



    }
}
