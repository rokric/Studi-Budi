using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyLogic.Helpers
{
    public static class UserFactory
    {
        public static IUser Build(string userName, string password, string type)
        {
            if (type.Equals("student"))
            {
                return  new Student(userName, password);
            }
            else if(type.Equals("teacher"))
            {
                return new Teacher(userName, password);
            }

            return null;
        }
    }
}
