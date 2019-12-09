using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Models
{
    public class FAQ
    {
        public int ID { get; set; }
        public int TeacherID { get; set; }
        public int SubjectID { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }

        //current count of answered questions
        public int Answered { get; set; }

        //current points
        public int Points { get; set; }

        [ForeignKey("TeacherID")]
        public User User { get; set; }

        [ForeignKey("SubjectID")]
        public Subject Subject { get; set; }
    }
}
