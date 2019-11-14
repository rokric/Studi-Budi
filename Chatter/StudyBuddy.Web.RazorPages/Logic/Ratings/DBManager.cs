using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public class DBManager : IDBManager
    {
        private StudiBudiContext context;
        public DBManager(StudiBudiContext context)
        {
            this.context = context;
        }

        public string GetUserNameByID(int id)
        {
            return context.User.Where(u => u.Userid == id).Select(u => u.Nick).FirstOrDefault();
        }

        public Question FindQuestionById(int questionID)
        {
            IList<Question> questions = context.Question.ToList();
            Question question = questions.Where(q => q.QuestionID == questionID).FirstOrDefault();
            return question;
        }
    }
}
