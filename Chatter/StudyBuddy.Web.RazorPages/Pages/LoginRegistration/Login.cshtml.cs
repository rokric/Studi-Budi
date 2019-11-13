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

          public int StudentID = 4;

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
            Console.WriteLine(Profession);
            //Console.WriteLine(Profession.ToString());

            if (_logincheker.IsLogCorrect(Username.ToString(), Password.ToString()/*, Profession.ToString())*/))
                return RedirectToPage("../StudentPage/Index", new { studentID = _logincheker.GetUserIDByUserName(Username.ToString()) });
            else return Page();

        }
       
    }
}