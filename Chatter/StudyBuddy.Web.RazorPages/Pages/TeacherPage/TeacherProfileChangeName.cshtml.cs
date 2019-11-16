using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Profile;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class TeacherProfileChangeNameModel : PageModel
    {
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Name { get; set; }

        private int teacherID = CurrentUser.UserID;
        public string Msg;

        private IGetPassword _getPassword;
        private  ILoginChecker _logincheker;



        public TeacherProfileChangeNameModel(IGetPassword getPassword, ILoginChecker logincheker)
        {
            _getPassword = getPassword;
            _logincheker = logincheker;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (_getPassword.IsPasswordGood(Password) && _getPassword.IsPasswordGood(Name) && _getPassword.IsPasswordMaches(Password, teacherID))
            {

                if (_logincheker.GetProfessionByUserName(Name) != null)
                {
                    Msg = "Username is already taken";
                    return Page();
                }
                else
                {
                    // pakeisti name
                        await _getPassword.NameChange(Name, teacherID);
                        return RedirectToPage("/TeacherPage/TeacherProfile");
                }
            }
            else
            {
                Msg = "bad data, try again";
                return Page();
            }
        }
    }
}