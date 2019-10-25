using StudyBuddy.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy
{
    /*
   * Classes for UI and backend connection 
   * Loads or creates users
   */

    public class UserLoader
    {
        public IUser LoadUser(string userName, string password, string userType)
        {
            return UserFactory.Build(userName, password, userType); ;
        }
    }
}
