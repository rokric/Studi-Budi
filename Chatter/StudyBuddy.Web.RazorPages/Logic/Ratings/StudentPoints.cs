using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic.Ratings;
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
        private AddPointsEvent addPointsEvent = new AddPointsEvent();

        public StudentPoints(StudiBudiContext context, IDBManager manager)
        {
            this.context = context;
            this.manager = manager;
            addPointsEvent.AddPoints += AddPointsHandler;
        }

        private void AddPointsHandler(object sender, AddPointsEventArgs args)
        {
            AddPoints(args.QuestionID, args.Value);
        }

        private void AddPoints(int questionID, int value)
        {
            Question question = manager.FindQuestionById(questionID);
            context.Attach(question);
            question.Points = value;
            context.SaveChanges();
        }

        public List<int> GetValues()
        {
            List<int> values = new List<int>();
            for(int i = 10; i <= 100; i+=10)
            {
                values.Add(i);
            }

            return values;
        }

        public void RegisterPoints(int questionID, int value)
        {
            addPointsEvent.RegisterPoints(manager.FindQuestionById(questionID), value);
        }
    }
}
