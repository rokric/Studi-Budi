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
        public IActionResult OnPost()
        {
            if (_logincheker.IsLogCorrect(Username, Password, Profession))
                if (Profession == "student")
                {
                    CurrentUser.UserID = _logincheker.GetUserIDByUserName(Username);
                    return RedirectToPage("../StudentPage/Index");
                }
                if (Profession == "teacher")
                {
                    CurrentUser.UserID = _logincheker.GetUserIDByUserName(Username);
                    return RedirectToPage("../TeacherPage/Index");
                }    
                   
            else return Page();
        }
       
    }
}