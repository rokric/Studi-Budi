using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudyBuddy.Web.RazorPages.Pages.LoginRegistration
{
    public class RegistrationModel : PageModel
    {

        [BindProperty, Required]
        [StringLength(14, MinimumLength = 5)]
        public string Username { get; set; }
        [BindProperty, Required]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; }
        [BindProperty, Required, Compare(nameof(Password), ErrorMessage = "Make sure both passwords are the same")]
        public string Password2 { get; set; }
        [BindProperty]
        public string Profession { get; set; }
       
        public void OnGet()
        {

        }
    }
}