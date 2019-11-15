using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.StudentPage
{
    public class IndexModel : PageModel
    {
        private readonly IUserInfoLoader _userInfoLoader;
        private int studentID;

        public IndexModel(IUserInfoLoader userInfoLoader)
        {
            _userInfoLoader = userInfoLoader;
        }

        public string StudentName { get; private set; }

        public async Task OnGetAsync()
        {
            studentID = CurrentUser.UserID;
            StudentName = await _userInfoLoader.GetUserNameById(studentID);
        }
    }
}
