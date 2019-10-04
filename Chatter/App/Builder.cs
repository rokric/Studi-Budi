using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public static class Builder
    {
        public static User CreateNewUser(string userType, string userName, string password)
        {
            if(userType == "student")
            {
                return new Student(userName, password);
            }
            else if(userType == "teacher")
            {
                return new Teacher(userName, password);
            }
            else
            {
                return null;
            }
        }
    }
}
