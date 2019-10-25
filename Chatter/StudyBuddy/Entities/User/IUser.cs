using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyBuddy
{
    public interface IUser
    {
        string UserName { get; set; }
        string Password { get; set; }
        string GetDecryptedUserName();
    }
}
