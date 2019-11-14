using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public class TeacherPoints : ITeacherPoints
    {
        private IDBManager manager;
        private StudiBudiContext context;

        public TeacherPoints(IDBManager manager, StudiBudiContext context)
        {
            this.manager = manager;
            this.context = context;
        }

        public async Task<List<Question>> GetHistoryByTeacherID(int teacherID)
        {
            List<Question> questions = await context.Question.Where(q => q.TeacherName == manager.GetUserNameByID(teacherID)).ToListAsync();
            return questions;
        }

        public async Task<int> GetTotalPoints(int teacherID)
        {
            List<Question> questions = await context.Question.Where(q => q.TeacherName == manager.GetUserNameByID(teacherID)).ToListAsync();
            int result = questions.Select(q => q.Points).Sum();
            return result;
        }
    }
}
