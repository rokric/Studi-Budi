﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly IUserInfoLoader _userInfoLoader;
        private int StudentID;

        public IndexModel(IUserInfoLoader userInfoLoader)
        {
            _userInfoLoader = userInfoLoader;
        }

        public string StudentName { get; private set; }

        public async Task OnGetAsync(int studentID)
        {
            StudentID = studentID;
            CurrentUser.UserID = StudentID;
            StudentName = await _userInfoLoader.GetUserNameById(StudentID);
        }
    }
}
