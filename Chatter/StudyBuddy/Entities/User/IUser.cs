using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddyLogic
{
    public interface IUser
    {
        string UserName { get; set; }
        string Password { get; set; }
        string GetDecryptedUserName();
    }
}
