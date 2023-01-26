using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ImshahProject.Web.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string? LastName { get; set; }
        public string FullName => FirstName + "  " + LastName;
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Subject is required")]
        public string? Subject { get; set; }
        [Required(ErrorMessage = "Message is required")]
        public string? Message { get; set; }
    }
}
