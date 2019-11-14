using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public interface IStudentPoints
    {
        Task AddPoints(int questionID, int value);
        List<int> GetValues();
    }
}
