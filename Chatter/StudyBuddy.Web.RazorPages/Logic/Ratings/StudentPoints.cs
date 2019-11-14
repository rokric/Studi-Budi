using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public class StudentPoints : IStudentPoints
    {
        private StudiBudiContext context;
        private IDBManager manager;

        public StudentPoints(StudiBudiContext context, IDBManager manager)
        {
            this.context = context;
            this.manager = manager;
        }
        public void AddPoints(int questionID, int value)
        {
            Question question = manager.FindQuestionById(questionID);
            context.Attach(question);
            question.Points = value;
            context.SaveChangesAsync();
        }
    }
}
