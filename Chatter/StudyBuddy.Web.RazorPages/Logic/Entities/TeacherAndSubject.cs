using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Entities
{
    public class TeacherAndSubject
    {
        public string TeacherName { get; set; }
        public string SubjectTitle { get; set; }
        public int Points { get; set; }
        public int UnansweredCount { get; set; }
    }
}
