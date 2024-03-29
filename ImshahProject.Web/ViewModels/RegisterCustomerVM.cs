﻿using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ImshahProject.Web.ViewModels
{
    public class RegisterCustomerVM
    {
        [Display(Name = "Full name")]
        [Required(ErrorMessage = "FullName is required")]
        public string Name { get; set; } = null!;

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "EmailAddress is required")]
        public string EmailAddress { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "ConfirmPassword is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not Match")]
        public string ConfirmPassword { get; set; } = null!;
    
    }
}
