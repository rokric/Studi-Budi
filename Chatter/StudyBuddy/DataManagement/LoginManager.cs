using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyLogic.DataManagement
{
    public static class LoginManager
    {
        public static bool IsLoginAccepted(string userName, string password, string profession)
        {
            ChatServer.DataWriter check = new ChatServer.DataWriter(userName, password, profession);
            return check.IsLoginAccepted();
        }
        public static bool CheckIfUserNameIsAvailable(string userName)
        {
            ChatServer.DataWriter check = new ChatServer.DataWriter(userName);
            return check.IsNickAvailable();
        }
    }
}
