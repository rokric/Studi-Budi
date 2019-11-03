using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyLogic
{
    public class Teacher : User
    {
        private List<Subject> subjectsList = new List<Subject>();
        public Teacher (string userName) : base(userName)
        {
           
        }
        public Teacher(string userName, string password) : base(userName, password)
        {

        }

        public List<Subject> SubjectsList
        {
            get { return subjectsList; }
        }

        public override string Type
        {
            get { return "teacher"; }
        }
    }
}
