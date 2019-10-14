using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class Student : User
    {
        public Student(string userName, string password) : base(userName, password)
        {

        }

        public override string Type
        {
            get { return "student"; }
        }
    }
}
