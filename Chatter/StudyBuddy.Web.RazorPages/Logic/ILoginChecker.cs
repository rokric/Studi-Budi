using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public interface ILoginChecker
    {
        Task<int> IsLogCorrect(string username, string password, string profession);
        public int GetUserIDByUserName(string username);
        public string GetProfessionByUserName(string username);
    }
}
