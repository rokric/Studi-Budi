using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using StudyBuddyLogic;

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
            List<Question> questions = await context.Question.Where(q => q.TeacherName == manager.GetUserNameByID(teacherID)
                    && q.Status == 1).ToListAsync();
            questions = DecryptQuestions(questions);
            return questions;
        }

        private List<Question> DecryptQuestions(List<Question> questions)
        {
            List<Question> decryptedQuestions = questions;

            foreach (Question question in decryptedQuestions)
            {
                question.StudentName = Encryptor.Decrypt(question.StudentName);
            }

            return decryptedQuestions;
        }
    }
}
