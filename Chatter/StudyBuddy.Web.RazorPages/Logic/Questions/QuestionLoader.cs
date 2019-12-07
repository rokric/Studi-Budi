using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic.Entities;
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

            await GetGroupedQuestionsForTeacher(studentName);

            return DecryptQuestions(questions);
        }

        //gets questions that are not answered
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

        //returns decrypted questions grouped by student name and subject
        public async Task<List<QuestionGroup>> GetGroupedQuestionsForTeacher(string userName)
        {
            List<Question> questions = await _context.Question.Where(q => q.TeacherName.Equals(userName)).ToListAsync();
           
            var groupedQuestions =
                questions.Where(q => q.TeacherName.Equals(userName)).GroupBy(q => 
                    new { q.StudentName, q.SubjectTitle });

            List<QuestionGroup> questionGroups = new List<QuestionGroup>();

            foreach (var group in groupedQuestions)
            {
                QuestionGroupKey questionGroupKey = new QuestionGroupKey { SubjectTitle = group.Key.SubjectTitle, Name = group.Key.StudentName };
                List<Question> questionGroupQuestions = new List<Question>(); 
               
                foreach (var item in group)
                {
                    questionGroupQuestions.Add(item);
                }

                questionGroups.Add(new QuestionGroup { Key = DecryptGroupedQuestionsKey(questionGroupKey), Questions = questionGroupQuestions });
            }

            return questionGroups;
        }

        private QuestionGroupKey DecryptGroupedQuestionsKey(QuestionGroupKey questionGroupKey)
        {
            QuestionGroupKey decrypted = questionGroupKey;
            decrypted.Name = Encryptor.Decrypt(decrypted.Name);
            return decrypted;
        }
    }
}
