using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Ratings
{
    public class AddPointsEventArgs : EventArgs
    {
        public int QuestionID { get; set; }
        public int Value { get; set; }

        public AddPointsEventArgs(int questionID, int value)
        {
            QuestionID = questionID;
            Value = value;
        }
    }
}
