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
    public class StudentProfileChangePasswordModel : PageModel
    {

        [BindProperty]
        public string NewPasswords { get; set; }


        [BindProperty]
        public string OldPasswords { get; set; }



        private IProfile _getPasswords;

        private readonly int StudentID = CurrentUser.UserID;
        public string Msgs;

        public StudentProfileChangePasswordModel(IProfile getPassword)
        {
            _getPasswords = getPassword;
        }



        public async Task<IActionResult> OnPost()
        {
            if (_getPasswords.IsPasswordGood(NewPasswords) && _getPasswords.IsPasswordGood(OldPasswords) && _getPasswords.IsPasswordMaches(OldPasswords, StudentID))
            {
                await _getPasswords.PasswordChange(NewPasswords, StudentID);
                return RedirectToPage("/StudentPage/StudentProfile");
            }
            else
            {
                Msgs = "bad data, try again";
                return Page();
            }

        }
    }
}