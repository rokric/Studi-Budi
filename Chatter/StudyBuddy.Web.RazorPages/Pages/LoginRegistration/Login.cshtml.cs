using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StudyBuddy.Web.RazorPages.Pages.LoginRegistration
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Profession { get; set; }

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
            if(!String.IsNullOrEmpty(Username)||!String.IsNullOrEmpty(Password))
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
            }
        }
    }
}