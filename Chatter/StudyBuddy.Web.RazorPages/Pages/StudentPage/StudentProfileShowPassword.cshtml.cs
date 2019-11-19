using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Profile;

namespace StudyBuddy.Web.RazorPages.Pages.StudentPage
{
    public class StudentProfileShowPasswordModel : PageModel
    {

        [BindProperty]

        public string Passwordd { get; set; }



        private readonly IProfile _GetPassword;

        private int studentID = CurrentUser.UserID;
        public string Msge;

        public StudentProfileShowPasswordModel(IProfile getPassword)
        {
            _GetPassword = getPassword;
        }

        public IActionResult OnPost()
        {
            try
            {
                if (_GetPassword.IsPasswordMaches(Passwordd.Trim(), studentID))
                {
                    Msge = _GetPassword.GetPasswordByID(studentID);
                    return Page();
                }
                else
                {
                    Msge = "password is not correct";
                    return Page();
                }
            }
            catch (NullReferenceException)
            {
                Msge = "password can not be emty";
                return Page();
            }

        }

        public void OnGet()
        {

        }
    }
}