using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using StudyBuddyLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public class QuestionRegister : IQuestionRegister
    {
        private StudiBudiContext _context;
        private Action<int, string, string, string> HandleNewQuestion;

        public QuestionRegister(StudiBudiContext context)
        {
            _context = context;
        }

        public void Ask(int studentID, string teacherName, string message, string subjectTitle)
        {
            HandleNewQuestion = Create;
            HandleNewQuestion.Invoke(studentID, teacherName, message, subjectTitle);
        }

        private void Create(int studentID, string teacherName, string message, string subjectTitle)
        {
            string studentName = GetStudentNameById(studentID);
            bool isValid = ValidateData(studentName, teacherName, message, subjectTitle);

            if (isValid)
            {
                Question question = new Question
                {
                    TeacherName = Encryptor.Encrypt(teacherName),
                    Message = message,
                    StudentName = studentName,
                    Answer = "Not aswered yet",
                    Status = 0,
                    SubjectTitle = subjectTitle
                };

                _context.Add(question);
                _context.SaveChanges();
            }
        }

        private string GetStudentNameById(int studentID)
        {
            return _context.User.Where(u => u.Userid == studentID).Select(u => u.Nick).FirstOrDefault();
        }

        private bool ValidateData(string studentName, string teacherName, string message, string subjectTitle)
        {
            if (string.IsNullOrEmpty(studentName))
            {
                return false;
            }

            if (string.IsNullOrEmpty(teacherName))
            {
                return false;
            }

            if (string.IsNullOrEmpty(message))
            {
                return false;
            }

            if (string.IsNullOrEmpty(subjectTitle))
            {
                return false;
            }

            return true;
        }
    }
}
