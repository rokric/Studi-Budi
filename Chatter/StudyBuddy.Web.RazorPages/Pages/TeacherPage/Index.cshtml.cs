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

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class IndexModel : PageModel
    {
        private readonly StudiBudiContext _context;
        private readonly IUserInfoLoader _userInfoLoader;

        public int TeacherID { get; private set; }

        public IndexModel(StudiBudiContext context, IUserInfoLoader userInfoLoader)
        {
            _context = context;
            _userInfoLoader = userInfoLoader;
        }

        public string TeacherName { get; private set; }

        public async Task OnGetAsync(int teacherID)
        {
            TeacherID = teacherID;
            CurrentUser.UserID = TeacherID;
            TeacherName = await _userInfoLoader.GetUserNameById(teacherID);
        }
    }
}
