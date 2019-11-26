using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
    public class StudentProfileModel : PageModel
    {
        private readonly IUserInfoLoader _userInfoLoader;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private int studentID;
        public string StudentName;

        public StudentProfileModel(IUserInfoLoader userInfoLoader, IHttpContextAccessor httpContextAccessor)
        {
            _userInfoLoader = userInfoLoader;
            _httpContextAccessor = httpContextAccessor;
            studentID = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }


        public async Task OnGet()
        {
            StudentName = await _userInfoLoader.GetUserNameById(studentID);
        }
    }
}
