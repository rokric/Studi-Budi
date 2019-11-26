using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Profile;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class TeacherProfileModel : PageModel
    {
        private readonly IUserInfoLoader _userInfoLoader;
        private IHttpContextAccessor _httpContextAccessor;


        private int teacherID;
        public string TeacherName;

        public TeacherProfileModel(IUserInfoLoader userInfoLoader, IHttpContextAccessor httpContextAccessor)
        {
            _userInfoLoader = userInfoLoader;
            _httpContextAccessor = httpContextAccessor;
            teacherID = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }

        public async Task OnGet()
        {
            TeacherName = await _userInfoLoader.GetUserNameById(teacherID);
        }
    }
}
