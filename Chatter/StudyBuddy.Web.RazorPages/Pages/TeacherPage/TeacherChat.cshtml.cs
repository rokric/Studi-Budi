using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Entities;
using StudyBuddy.Web.RazorPages.Logic.Teacher;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class TeacherChatModel : PageModel
    {
        private readonly IQuestionLoader _questionLoader;
        private readonly IUserInfoLoader _userInfoLoader;
        private readonly IQuestionAnswerRegister _answerRegister;
        private readonly ITeacherActivity _teacherActivity;
        private IHttpContextAccessor _httpContextAccessor;

        public int TeacherID;

        [BindProperty]
        public string Answer { get; set; }


        //properties for reporting student
        [BindProperty, Required]
        public string ReportMessage { get; set; }
        [BindProperty]
        public string StudentName { get; set; }
        public string ReportError { get; set; }

        public TeacherChatModel(IQuestionLoader questionLoader, IUserInfoLoader userInfoLoader, IQuestionAnswerRegister answerRegister,
            IHttpContextAccessor httpContextAccessor, ITeacherActivity teacherActivity)
        {
            _questionLoader = questionLoader;
            _userInfoLoader = userInfoLoader;
            _answerRegister = answerRegister;
            _teacherActivity = teacherActivity;
            _httpContextAccessor = httpContextAccessor;
        }

        //public IList<Question> Questions { get; set; }
        public List<QuestionGroup> Questions { get; set; }

        public async Task<IActionResult> OnGetAsync(string message = null)
        {
            TeacherID = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            //Questions = await _questionLoader.GetQuestions(await _userInfoLoader.GetEncryptedUserNameById(TeacherID), "teacher");
            Questions = await _questionLoader.GetGroupedQuestionsForTeacher(await _userInfoLoader.GetEncryptedUserNameById(TeacherID));

            if(message != null)
            {
                ModelState.AddModelError("ReportError", message);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int questionID)
        {
            try
            {
                await _answerRegister.RegisterAnswer(questionID, Answer);
            }
            catch(ArgumentException exc)
            {
                return RedirectToAction("OnGetAsync", new { message = exc.Message});
            }

            

            return RedirectToPage();
        }

        public IActionResult OnPostReport()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("OnGetAsync", new { message = "Report message cannot be empty!" });
            }

            _teacherActivity.ReportStudent(StudentName, ReportMessage);

            return RedirectToPage();
        }
    }
}

