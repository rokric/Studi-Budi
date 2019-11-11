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
    public class QuestionLoader : IQuestionLoader
    {
        private IStudiBudiContext _context;

        public QuestionLoader(IStudiBudiContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetQuestions(string studentName)
        {
            List<Question> questions = await _context.Question.Where(q => q.StudentName.Equals(studentName)).ToListAsync();

            return DecryptQuestions(questions);
        }

        private List<Question> DecryptQuestions(List<Question> questions)
        {
            List<Question> decryptedQuestions = questions;

            foreach(Question question in decryptedQuestions)
            {
                question.TeacherName = Encryptor.Decrypt(question.TeacherName);
            }

            return decryptedQuestions;
        }
    }
}
