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

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class IndexModel : PageModel
    {
        private readonly IUserInfoLoader _userInfoLoader;
        private IHttpContextAccessor _httpContextAccessor;

        public IndexModel(IUserInfoLoader userInfoLoader, IHttpContextAccessor httpContextAccessor)
        {
            _userInfoLoader = userInfoLoader;
            _httpContextAccessor = httpContextAccessor;
        }

        public string TeacherName { get; private set; }

        public async Task OnGetAsync()
        {
            TeacherName = await _userInfoLoader.GetUserNameById(int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }
    }
}
