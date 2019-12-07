using StudyBuddy.Web.RazorPages.Logic.Entities;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public interface IQuestionLoader
    {
        Task<List<Question>> GetQuestions(string userName, string userType);
        Task<List<QuestionGroup>> GetGroupedQuestionsForTeacher(string userName);
    }
}
