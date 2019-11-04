using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyLogic
{
    public class UserRegistry
    {
        public void CreateUser(string userName, string password, string userType)
        {
            DataManager.AddData(userName, password, userType);
        }
    }
}
