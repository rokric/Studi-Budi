using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Ratings
{
    public class Points : IPoints
    {
        private IDBManager manager;
        private StudiBudiContext context;

        public Points(IDBManager manager, StudiBudiContext context)
        {
            this.manager = manager;
            this.context = context;
        }

        public async Task<int> GetTotalPoints(int teacherID)
        {
            List<Question> questions = await context.Question.Where(q => q.TeacherName == manager.GetUserNameByID(teacherID)).ToListAsync();
            int result = questions.Select(q => q.Points).Sum();
            return result;
        }
    }
}
