﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Entities;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.StudentPage
{
    public class InboxModel : PageModel
    {
        private IQuestionLoader _questionLoader;
        private IUserInfoLoader _userInfoLoader;
       
        public List<QuestionGroup> Questions { get; set; }

        public InboxModel(IQuestionLoader questionLoader, IUserInfoLoader userInfoLoader)
        {
            _questionLoader = questionLoader;
            _userInfoLoader = userInfoLoader;
        }


        public async Task OnGetAsync(int studentID)
        {
            Questions = await _questionLoader.GetGroupedQuestionsForStudent(await _userInfoLoader.GetEncryptedUserNameById(studentID));
        }
    }
}
