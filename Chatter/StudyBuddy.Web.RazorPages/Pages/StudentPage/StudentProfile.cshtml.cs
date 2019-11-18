using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.StudentPage
{
    public class StudentProfileModel : PageModel
    {
        private readonly StudyBuddy.Web.RazorPages.Data.StudiBudiContext _context;

        /*public StudentProfileModel(StudyBuddy.Web.RazorPages.Data.StudiBudiContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }*/


        private readonly IUserInfoLoader _userInfoLoader;



        private int studentID = CurrentUser.UserID;
        public string StudentName;




        public StudentProfileModel(IUserInfoLoader userInfoLoader)
        {
            _userInfoLoader = userInfoLoader;
        }


        public async Task OnGet()
        {
            StudentName = await _userInfoLoader.GetUserNameById(studentID);
        }
    }
}
