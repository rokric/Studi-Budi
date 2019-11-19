using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Profile;
using System.ComponentModel.DataAnnotations;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class TeacherProfileShowPasswordModel : PageModel
    {

        [BindProperty]

        public string Passwordd { get; set; }



        private readonly IProfile _GetPassword;

        private int teachersID = CurrentUser.UserID;
        public string Msge;

        public TeacherProfileShowPasswordModel( IProfile getPassword)
        {
            _GetPassword = getPassword;
        }

        public IActionResult OnPost()
        {
            try
            {
                if (_GetPassword.IsPasswordMaches(Passwordd.Trim(), teachersID))
                {
                    Msge = _GetPassword.GetPasswordByID(teachersID);
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