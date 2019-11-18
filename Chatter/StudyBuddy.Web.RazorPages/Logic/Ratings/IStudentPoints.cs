using StudyBuddy.Web.RazorPages.Logic.Ratings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public interface IStudentPoints
    {
        void RegisterPoints(int questionID, int value);
        List<int> GetValues();
    }
}
