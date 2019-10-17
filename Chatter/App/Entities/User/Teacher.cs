using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Teacher : User
    {
        public Teacher (string userName) : base(userName)
        {
          
        }
        public Teacher(string userName, string password) : base(userName, password)
        {

        }

        public List<Subject> SubjectsList { get; }

        public override string Type
        {
            get { return "teacher"; }
        }
    }
}
