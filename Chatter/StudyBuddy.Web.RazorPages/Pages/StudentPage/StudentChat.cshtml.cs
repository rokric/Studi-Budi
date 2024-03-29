﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        private IHttpContextAccessor _httpContextAccessor;

        public IList<TeacherAndSubject> TeachersAndSubjects { get; set; }

        public SelectList SubjectsTitles { get; set; }

        public int StudentID { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SubjectTitleFilter { get; set; } //table filter

        public StudentChatModel(IStudentActivity studentActivity, IHttpContextAccessor httpContextAccessor)
        {
            _studentActivity = studentActivity;
            _httpContextAccessor = httpContextAccessor;
             StudentID = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
        public async Task OnGetAsync()
        {
            List<TeacherAndSubject> teachersAndSubjects = await _studentActivity.GetTeachersAndSubjects();
            teachersAndSubjects =_studentActivity.FilterTeachersAndSubjects(SubjectTitleFilter, teachersAndSubjects);
            SubjectsTitles = new SelectList(await _studentActivity.GetSubjectsTitles());
            TeachersAndSubjects = teachersAndSubjects;
        }
    }
}
