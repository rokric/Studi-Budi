﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyBuddy.Web.RazorPages.Logic;

namespace StudyBuddy.Web.RazorPages.Pages.StudentPage
{
    public class AskModel : PageModel
    {
        private IQuestionRegister _questionRegister;

        [BindProperty]
        public string Message { get; set; }

        public AskModel(IQuestionRegister questionRegister)
        {
            _questionRegister = questionRegister;
        }

        public IActionResult OnPost(string teacherName, int studentID, string subjectTitle)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _questionRegister.Ask(studentID, teacherName, Message, subjectTitle);

            return RedirectToPage("/StudentPage/StudentChat");
        }
    }
}