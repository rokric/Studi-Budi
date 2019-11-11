using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.StudentPage
{
    public class InboxModel : PageModel
    {
        private IQuestionLoader _questionLoader;
        private IUserInfoLoader _userInfoLoader;
        public InboxModel(IQuestionLoader questionLoader, IUserInfoLoader userInfoLoader)
        {
            _questionLoader = questionLoader;
            _userInfoLoader = userInfoLoader;
        }

        public IList<Question> Questions { get;set; }

        public async Task OnGetAsync(int studentID)
        {
            Questions = await _questionLoader.GetQuestions(await _userInfoLoader.GetEncryptedUserNameById(studentID), "student");
        }
    }
}
