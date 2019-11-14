using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages
{
    public interface ITeacherPoints
    {
        Task<List<Question>> GetHistoryByTeacherID(int teacherID);
        Task<int> GetTotalPoints(int teacherID);
    }
}
