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

namespace StudyBuddy.Web.RazorPages.Pages.StudentPage
{
    public class StudentProfileModel : PageModel
    {
        private readonly StudyBuddy.Web.RazorPages.Data.StudiBudiContext _context;
        private readonly IUserInfoLoader _userInfoLoader;


        public StudentProfileModel(IUserInfoLoader userInfoLoader)
        {
            _userInfoLoader = userInfoLoader;
        }

        public int StudentId { get; private set;  }
        public string StudentName { get; private set; }




        public async Task OnGet()
        {
            StudentId = 4;
            StudentName = await _userInfoLoader.GetUserNameById(StudentId);
        }
    }
}
