﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class TeacherChatModel : PageModel
    {
        private readonly IQuestionLoader _questionLoader;
        private readonly IUserInfoLoader _userInfoLoader;
        private readonly IQuestionAnswerRegister _answerRegister;

        public int TeacherID;

        [BindProperty]
        public string Answer { get; set; }
        public TeacherChatModel(IQuestionLoader questionLoader, IUserInfoLoader userInfoLoader, IQuestionAnswerRegister answerRegister)
        {
            _questionLoader = questionLoader;
            _userInfoLoader = userInfoLoader;
            _answerRegister = answerRegister;
        }

        public IList<Question> Questions { get; set; }

        public async Task OnGetAsync()
        {
            TeacherID = CurrentUser.UserID;
            Questions = await _questionLoader.GetQuestions(await _userInfoLoader.GetEncryptedUserNameById(TeacherID), "teacher");
        }

        public async Task<IActionResult> OnPostAsync(int questionID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _answerRegister.RegisterAnswer(questionID, Answer);

            return RedirectToPage("/TeacherPage/TeacherChat");
        }
    }
}

