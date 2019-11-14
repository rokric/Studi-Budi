using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Ratings
{
    public interface IPoints
    {
        Task<int> GetTotalPoints(int teacherID);
    }
}
