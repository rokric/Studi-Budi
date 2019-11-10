using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string StudentName { get; set; }
        public string TeacherName { get; set; }
        public string SubjectTitle { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public string Answer { get; set; }
    }
}
