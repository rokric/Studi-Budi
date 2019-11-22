using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        private int teacherId;
        public string Mesg;

        private IProfile _GetPasswords;
        private  ILoginChecker _loginchekers;
        private IHttpContextAccessor _httpContextAccessor;



        public TeacherProfileChangeNameModel(IProfile getPassword, ILoginChecker logincheker, IHttpContextAccessor httpContextAccessor)
        {
            _GetPasswords = getPassword;
            _loginchekers = logincheker;
            _httpContextAccessor = httpContextAccessor;
            teacherId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
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