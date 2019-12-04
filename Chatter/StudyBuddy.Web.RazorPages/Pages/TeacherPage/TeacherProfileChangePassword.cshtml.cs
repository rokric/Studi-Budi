using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class TeacherProfileChangePasswordModel : PageModel
    {



        [BindProperty]
        public string NewPasswords { get; set; }

 
        [BindProperty]
        public string OldPasswords { get; set; }



        private IProfile _getPasswords;
        private IHttpContextAccessor _httpContextAccessor;

        private readonly int TeacherID;
        public string Msgs;

        public TeacherProfileChangePasswordModel(IProfile getPassword, IHttpContextAccessor httpContextAccessor)
        {
            _getPasswords = getPassword;
            _httpContextAccessor = httpContextAccessor;
            TeacherID = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        public void OnGet()
        {
        }


/*
        public async Task<IActionResult> OnPost()
        {
            if (_getPasswords.IsPasswordGood(NewPasswords) && _getPasswords.IsPasswordGood(OldPasswords) && _getPasswords.IsPasswordMaches(OldPasswords, TeacherID))
            {
                await _getPasswords.PasswordChange(NewPasswords, TeacherID);
                return RedirectToPage("/TeacherPage/TeacherProfile");
            }
            else
            {
                Msgs = "bad data, try again";
                return Page();
            }
            
        }*/
    }
}