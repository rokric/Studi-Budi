using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Entities;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.StudentPage
{
    public class StudentChatModel : PageModel
    {
        private IStudentActivity _studentActivity;

        public IList<TeacherAndSubject> TeachersAndSubjects { get; set; }

        public SelectList SubjectsTitles { get; set; }

        public int StudentID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SubjectTitleFilter { get; set; } //table filter

        public StudentChatModel(IStudentActivity studentActivity)
        {
            _studentActivity = studentActivity;
        }
        public async Task OnGetAsync()
        {
            StudentID = CurrentUser.UserID;
            List<TeacherAndSubject> teachersAndSubjects = await _studentActivity.GetTeachersAndSubjects();
            teachersAndSubjects =_studentActivity.FilterTeachersAndSubjects(SubjectTitleFilter, teachersAndSubjects);
            SubjectsTitles = new SelectList(await _studentActivity.GetSubjectsTitles());
            TeachersAndSubjects = teachersAndSubjects;
        }
    }
}
