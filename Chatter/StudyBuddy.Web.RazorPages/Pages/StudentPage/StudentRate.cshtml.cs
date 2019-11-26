using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.StudentPage
{
    public class StudentRateModel : PageModel
    {
        private IStudentPoints _studentPoints;
        private IHttpContextAccessor _httpContextAccessor;
        [BindProperty]
        public int Value { get; set; }

        public SelectList Options { get; set; }

        public StudentRateModel(IStudentPoints studentsPoints, IHttpContextAccessor httpContextAccessor)
        {
            _studentPoints = studentsPoints;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult OnGet()
        {
            Options = new SelectList(_studentPoints.GetValues());
            return Page();
        }

        public IActionResult OnPost(int questionID)
        {
            _studentPoints.RegisterPoints(questionID, Value);
            return RedirectToPage("/StudentPage/Inbox", new { studentID = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value) });
        }
    }
}
