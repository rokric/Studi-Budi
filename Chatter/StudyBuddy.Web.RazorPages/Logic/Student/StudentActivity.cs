using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic.Entities;
using StudyBuddy.Web.RazorPages.Models;
using StudyBuddyLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public class StudentActivity : IStudentActivity
    {
        private IStudiBudiContext _context;

        public StudentActivity(IStudiBudiContext context)
        {
            _context = context;
        }

        public List<TeacherAndSubject> FilterTeachersAndSubjects(string filter, List<TeacherAndSubject> teachersAndSubjects)
        {
            if (!string.IsNullOrEmpty(filter))
            {
                teachersAndSubjects = teachersAndSubjects.Where(x => x.SubjectTitle == filter).ToList();

                teachersAndSubjects.Sort((a, b) => b.Points.CompareTo(a.Points));
            }

            return teachersAndSubjects;
        }

        private int GetSubjectIdByTitle(string title)
        {
            return _context.Subject.Where(s => s.Title.Equals(title)).Select(s => s.Subjectid).FirstOrDefault();
        }

        public async Task<List<string>> GetSubjectsTitles()
        {
            List<string> subjects = await _context.Subject.Select(s => s.Title).ToListAsync();
            return subjects;
        }

        private string GetSubjectTitleById(int id)
        {
            return _context.Subject.Where(s => s.Subjectid == id).Select(s => s.Title).FirstOrDefault();
        }

        private string GetTeacherNameById(int id)
        {
            string userName = _context.User.Where(u => u.Userid == id).Select(u => u.Nick).FirstOrDefault();
            return Encryptor.Decrypt(userName);
        }

        public async Task<List<TeacherAndSubject>> GetTeachersAndSubjects()
        {
            List<Teaching> teachings = await _context.Teaching.ToListAsync();

            List<TeacherAndSubject> teachersAndSubjects = teachings.Select(t => new TeacherAndSubject
            {
                TeacherName = GetTeacherNameById(t.Userid),
                SubjectTitle = GetSubjectTitleById(t.Subjectid),
                
            }).ToList();


            foreach (TeacherAndSubject item in teachersAndSubjects)
            {
                item.Points = await GetPointsBySubjectAndTeacherName(item.SubjectTitle, item.TeacherName);
                item.UnansweredCount = await GetUnansweredCount(item.SubjectTitle, item.TeacherName);
            }

            teachersAndSubjects.Sort((a, b) => b.Points.CompareTo(a.Points));

            return teachersAndSubjects;
        }

        private async Task<int> GetPointsBySubjectAndTeacherName(string subjectTitle, string teacherName)
        {
            teacherName = Encryptor.Encrypt(teacherName);
            List<Question> questions = await _context.Question.ToListAsync();
            int value = questions.Where(q => q.SubjectTitle.Equals(subjectTitle) && q.TeacherName.Equals(teacherName)).Select(
                q => q.Points).Sum();
            return value;
        }

        private async Task<int> GetUnansweredCount(string subjectTitle, string teacherName)
        {
            teacherName = Encryptor.Encrypt(teacherName);
            List<Question> questions = await _context.Question.ToListAsync();
            int value = questions.Where(q => q.SubjectTitle.Equals(subjectTitle) && q.TeacherName.Equals(teacherName) && q.Status == 0).Count();
            return value;
        }

        public async Task<List<StudentFAQ>> GetFAQs()
        {
            List<StudentFAQ> studentFAQs = new List<StudentFAQ>();
            List<FAQ> fAQs = await _context.FAQ.ToListAsync();

            studentFAQs = fAQs.Select(f =>
                new StudentFAQ
                {
                    Name = GetTeacherNameById(f.TeacherID),
                    Answer = f.Answer,
                    Answered = f.Answered,
                    Points = f.Points,
                    Question = f.Question
                }
            ).ToList();

            return studentFAQs;
        }
    }
}
