using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Teacher;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class SubjectsModel : PageModel
    {
        private ITeacherActivity _teacherActivity;
        private IHttpContextAccessor _httpContextAccessor;

        public SubjectsModel(ITeacherActivity teacherActivity, IHttpContextAccessor httpContextAccessor)
        {
            _teacherActivity = teacherActivity;
            _httpContextAccessor = httpContextAccessor;
            TeacherID = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        public int TeacherID { get; set; }
        public List<string> MySubjects = new List<string>();

        public async Task OnGetAsync()
        {
            MySubjects = await _teacherActivity.GetMySubjects(TeacherID);
        }

        public async Task<IActionResult> OnPostDeleteAsync(string subjectTitle)
        {
            await _teacherActivity.DeleteSubject(TeacherID, subjectTitle);
            return Redirect("/TeacherPage/Subjects");
        }
    }
}
