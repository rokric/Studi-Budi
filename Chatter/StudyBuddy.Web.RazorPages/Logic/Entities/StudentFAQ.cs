using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Entities
{
    public class StudentFAQ
    {
        public string Name { get; set; }
        public string Answer { get; set; }
        public string Question { get; set; }
        public int Points { get; set; }
        public int Answered { get; set; }

        public string Subject { get; set; }
    }
}
