using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Web.Mvc.Controls;
using StudyBuddy.Web.RazorPages.Logic;

namespace StudyBuddy.Web.RazorPages.Pages.LoginRegistration
{
    public class RegistrationModel : PageModel
    {
        private readonly ILoginChecker _logincheker;
        private readonly IUserInfoRegister _userinforegister;

        public RegistrationModel(ILoginChecker loginCheker, IUserInfoRegister userinforegister)
        {
            _logincheker = loginCheker;
            _userinforegister = userinforegister;
        }
        public string Msg { get; set; }
        [BindProperty, Required]
        [StringLength(14, MinimumLength = 5)]
        public string Username { get; set; }
        [BindProperty, Required]
        [StringLength(20, MinimumLength = 5)]
        public string Password { get; set; }
        [BindProperty, Compare(nameof(Password), ErrorMessage = "Make sure both passwords are the same")]
        public string Password2 { get; set; }

        [BindProperty, Required]
        public string Profession { get; set; }
       
        public IActionResult OnPost()
        {
            if (_logincheker.GetProfessionByUserName(Username)!=null)//exception
            {
                Msg = "Username is already taken";
                return RedirectToPage("Registration");
            }
            else
            {
                _userinforegister.WriteUserInfo(Username, Password, Profession);
                return RedirectToPage("Login");
            }
        }
    }
}