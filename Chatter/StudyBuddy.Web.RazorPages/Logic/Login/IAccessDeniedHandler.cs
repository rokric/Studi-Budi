using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public interface IAccessDeniedHandler
    {
        bool IsAccessDenied(int userID);
    }
}
