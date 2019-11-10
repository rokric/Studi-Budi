using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using StudyBuddy.Web.RazorPages.Logic;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class TeacherProfileModel : PageModel
    {
        private readonly StudyBuddy.Web.RazorPages.Data.StudiBudiContext _context;
        private readonly IUserInfoLoader _userInfoLoader;

        public TeacherProfileModel(IUserInfoLoader userInfoLoader)
        {
            _userInfoLoader = userInfoLoader;
        }

        public int TeacherID { get; private set; }
        public string TeacherName { get; private set; }


        public async Task OnGet()
        {
            TeacherID = 4;
            TeacherName = await _userInfoLoader.GetUserNameById(TeacherID);
        }
        


    }
}
