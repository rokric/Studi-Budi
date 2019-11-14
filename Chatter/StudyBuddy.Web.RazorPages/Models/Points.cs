using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Models
{
    public class Points
    {
        public int PointsID { get; set; }
        public int QuestionID { get; set; }
        public int Value { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}
