using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Teacher;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class ShareModel : PageModel
    {
        private ITeacherActivity _teacherActivity;
        public SelectList SubjectsTitles { get; set; }
        public int TeacherID { get; set; }

        [BindProperty]
        public string SubjectTitle { get; set; }

        [BindProperty, Required]
        public string Question { get; set; }

        [BindProperty, Required]
        public string Answer { get; set; }

        public ShareModel(ITeacherActivity teacherActivity)
        {
            _teacherActivity = teacherActivity;
        }

        public async Task OnGet(int teacherID)
        {
            SubjectsTitles = new SelectList(await _teacherActivity.GetMySubjects(teacherID));
        }

        public async Task<IActionResult> OnPostAsync(int teacherID)
        {
            await _teacherActivity.Share(teacherID, SubjectTitle, Question, Answer);
            return RedirectToPage("./TeacherChat");
        }
    }
}