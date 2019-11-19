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
        public string Passwordas { get; set; }
        [BindProperty]
        public string Names { get; set; }

        private int teacherId = CurrentUser.UserID;
        public string Mesg;

        private IProfile _GetPasswords;
        private  ILoginChecker _loginchekers;



        public TeacherProfileChangeNameModel(IProfile getPassword, ILoginChecker logincheker)
        {
            _GetPasswords = getPassword;
            _loginchekers = logincheker;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {

            if (_GetPasswords.IsPasswordGood(Passwordas) && _GetPasswords.IsPasswordGood(Names) && _GetPasswords.IsPasswordMaches(Passwordas, teacherId))
            {

                if (_loginchekers.GetProfessionByUserName(Names) != null)
                {
                    Mesg = "Username is already taken";
                    return Page();
                }
                else
                {
                    // pakeisti name
                        await _GetPasswords.NameChange(Names, teacherId);
                        return RedirectToPage("/TeacherPage/TeacherProfile");
                }
            }
            else
            {
                Mesg = "bad data, try again";
                return Page();
            }
        }
    }
}