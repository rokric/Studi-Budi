using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyLogic
{
    public interface IRegistration
    {
        void IsUserNameValid(string userName, out string message);
        void IsPasswordValid(string password, out string message);
        void IsPasswordMatch(string password, string passwordRepeat, out string message);
    }
}
