using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Profile
{
    public interface IGetPassword
    {
        bool IsPasswordMaches(string password, int ID);
        public string GetPasswordByID(int ID);

    }
}
