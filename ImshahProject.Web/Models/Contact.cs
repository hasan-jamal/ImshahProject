using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImshahProject.Web.Models
{
    public partial class Contact
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string FullName => FirstName + "  " + LastName;
        public string? Email { get; set; }
        public string? Subject { get; set; }
        public string? Message { get; set; }
    

    }
}
