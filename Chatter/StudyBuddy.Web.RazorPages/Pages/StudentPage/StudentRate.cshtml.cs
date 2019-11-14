using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        [BindProperty]
        public int Value { get; set; }

        public SelectList Options { get; set; }

        public StudentRateModel(IStudentPoints studentsPoints)
        {
            _studentPoints = studentsPoints;
        }

        public IActionResult OnGet()
        {
            Options = new SelectList(_studentPoints.GetValues());
            return Page();
        }

        public async Task<IActionResult> OnPost(int questionID)
        {
            await _studentPoints.AddPoints(questionID, Value);
            return RedirectToPage("/StudentPage/Inbox", new { studentID = CurrentUser.UserID });
        }
    }
}
