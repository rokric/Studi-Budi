using StudyBuddy.Web.RazorPages.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public interface IUserInfoLoader
    {
        Task<string> GetUserNameById(int id);

        Task<string> GetEncryptedUserNameById(int id);
    }
}
