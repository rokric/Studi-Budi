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
        private readonly IUserInfoLoader _userInfoLoader;
        private int teacherID;

        public IndexModel(IUserInfoLoader userInfoLoader)
        {
            _userInfoLoader = userInfoLoader;
        }

        public string TeacherName { get; private set; }

        public async Task OnGetAsync()
        {
            teacherID = CurrentUser.UserID;
            TeacherName = await _userInfoLoader.GetUserNameById(teacherID);
        }
    }
}
