using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyBuddy.Web.RazorPages.Logic;

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

        [BindProperty]
        public string Profession { get; set; }
        #endregion

        private readonly ILoginChecker _logincheker;
        public string LoginFailed { get; set; }

        public LoginModel(ILoginChecker loginCheker)
        {
            _logincheker = loginCheker;
        }
        public void OnGet()
        {

        }
        public IActionResult OnGetLogout()
        {
            HttpContext.Session.Remove("username");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            int loginStatus = await _logincheker.IsLogCorrect(Username, Password, Profession);
            if (loginStatus == 0)
            {
                if (Profession == "student")
                {
                    return RedirectToPage("../StudentPage/Index");
                }
                else if (Profession == "teacher")
                {
                    return RedirectToPage("../TeacherPage/Index");
                }
            }
            else if(loginStatus == 1)
            {
                return RedirectToPage("../AdminPage/Index");
            }
            else
            {
                ModelState.AddModelError("LoginFailed", "Invalid login attempt.");
            }

            return Page();
        }
    }
}