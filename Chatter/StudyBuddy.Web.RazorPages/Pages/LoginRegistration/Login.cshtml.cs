using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudyBuddy.Web.RazorPages.Pages.LoginRegistration
{
    public class LoginModel : PageModel
    {
        #region Properties
        [BindProperty, Required]
        public string Username { get; set; }
        [BindProperty, Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

          public int StudentID = 4;

        [BindProperty]
        [Display(Name = "Profession")]

      
        public string Profession { get; set; }
        #endregion
        public string Msg;
        public void OnGet()
        {

        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return Page();
        }
        public IActionResult OnPost()
        {
            /*if(!String.IsNullOrEmpty(Username)||!String.IsNullOrEmpty(Password))
            {
                if (Username.Equals("aaa") && Password.Equals("aaa"))
                {
                    HttpContext.Session.SetString("username", Username);
                    return RedirectToPage("Logged");
                }
                else
                {
                    Msg = "Invalid";
                    return Page();
                }
            }
            else {
                Msg = "Invalid";
                return Page();
            }*/

            return RedirectToPage("../StudentPage/Index", new { studentID = StudentID });


        }
    }
}