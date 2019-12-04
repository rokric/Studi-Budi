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

namespace StudyBuddy.Web.RazorPages.Pages.StudentPage
{
    public class StudentProfileChangePasswordModel : PageModel
    {

        [BindProperty]
        public string NewPasswords { get; set; }


        [BindProperty]
        public string OldPasswords { get; set; }



        private IProfile _getPasswords;
        private IHttpContextAccessor _httpContextAccessor;

        private readonly int StudentID;
        public string Msgs;

        public StudentProfileChangePasswordModel(IProfile getPassword, IHttpContextAccessor httpContextAccessor)
        {
            _getPasswords = getPassword;
            _httpContextAccessor = httpContextAccessor;
            StudentID = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }



  /*      public async Task<IActionResult> OnPost()
        {
          /*  if (_getPasswords.IsPasswordGood(NewPasswords) && _getPasswords.IsPasswordGood(OldPasswords) && _getPasswords.IsPasswordMaches(OldPasswords, StudentID))
            {
                await _getPasswords.PasswordChange(NewPasswords, StudentID);
                return RedirectToPage("/StudentPage/StudentProfile");
            }
            else
            {
                Msgs = "bad data, try again";
                return Page();
            }

        }*/
    }
}