using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Ratings
{
    public class AddPointsEvent
    {
        public event EventHandler<AddPointsEventArgs> AddPoints;

        public void RegisterPoints(Question question, int value)
        {
            if (question.Points == 0 && question.Status == 1)
            {
                AddPoints?.Invoke(this, new AddPointsEventArgs(question.QuestionID, value));
            }
        }
    }
}
