using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyBuddy.Web.RazorPages.Logic;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class TeacherProfileChangeNameModel : PageModel
    {

        public string Password;
        public string Name;

        private int teacherID = CurrentUser.UserID;
        public string Msg;


        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            Msg = "Coming SOON!!!!";
        }
    }
}