using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic.Teacher;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class AddModel : PageModel
    {
        private ITeacherActivity _teacherActivity;

        [BindProperty]
        public int SubjectID { get; set; }
        public List<SelectListItem> Options { get; set; }

        public AddModel(ITeacherActivity teacherActivity)
        {
            _teacherActivity = teacherActivity;
        }

        public async Task<IActionResult> OnGetAsync(int teacherID)
        {
            IList<Subject> availableSubjects = await _teacherActivity.GetAvailableSubjects(teacherID);
            Options = availableSubjects.Select(s =>
                                                    new SelectListItem
                                                    {
                                                        Value = s.Subjectid.ToString(),
                                                        Text = s.Title
                                                    }).ToList();
            return Page();
        }

        public IActionResult OnPost(int teacherID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _teacherActivity.AddSubject(teacherID, SubjectID);

            return RedirectToPage("./Subjects");
        }
    }
}
