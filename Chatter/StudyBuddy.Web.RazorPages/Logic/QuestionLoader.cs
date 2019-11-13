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
        private readonly IStudiBudiContext _context;
        private Func<string, Task<List<Question>>> questionsGetter;

        public QuestionLoader(IStudiBudiContext context)
        {
            _context = context;
        }

        public async Task<List<Question>> GetQuestions(string studentName, string userType)
        {
            if (userType.Equals("teacher"))
            {
                questionsGetter = GetQuestionsForTeacher;
            }
            else if (userType.Equals("student"))
            {
                questionsGetter = GetQuestionsForStudent;
            }
            else
            {
                throw new ArgumentException("user type must be student or teacher");
            }

            List<Question> questions = await questionsGetter.Invoke(studentName);

            return DecryptQuestions(questions);
        }

        private async Task<List<Question>> GetQuestionsForTeacher(string userName)
        {
            List<Question> questions = await _context.Question.Where(q => q.TeacherName.Equals(userName) && q.Status == 0).ToListAsync();
            return questions;
        }

        private async Task<List<Question>> GetQuestionsForStudent(string userName)
        {
            List<Question> questions = await _context.Question.Where(q => q.StudentName.Equals(userName)).ToListAsync();
            return questions;
        }

        private List<Question> DecryptQuestions(List<Question> questions)
        {
            List<Question> decryptedQuestions = questions;

            foreach(Question question in decryptedQuestions)
            {
                question.TeacherName = Encryptor.Decrypt(question.TeacherName);
                question.StudentName = Encryptor.Decrypt(question.StudentName);
            }

            return decryptedQuestions;
        }
    }
}
