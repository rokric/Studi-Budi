using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Profile;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class TeacherProfileShowPasswordModel : PageModel
    {

        [BindProperty]

        public string Passwordd { get; set; }



        private readonly IProfile _GetPassword;
        private IHttpContextAccessor _httpContextAccessor;

        private int teachersID;
        public string Msge;

        public TeacherProfileShowPasswordModel(IProfile getPassword, IHttpContextAccessor httpContextAccessor)
        {
            _GetPassword = getPassword;
            _httpContextAccessor = httpContextAccessor;
            teachersID = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
/*
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

        }*/
    }
}