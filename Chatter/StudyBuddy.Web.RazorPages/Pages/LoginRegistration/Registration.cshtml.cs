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
        [BindProperty]
        [StringLength(14, MinimumLength = 5)]
        [Required]
        public string Username { get; set; }
        [BindProperty]
        [StringLength(20, MinimumLength = 5)]
        [Required]
        public string Password { get; set; }
        [BindProperty]
    //    [Compare(Password)]
        public string Password2 { get; set; }
        [BindProperty]
        public string Profession { get; set; }
       
        public void OnGet()
        {

        }
    }
}