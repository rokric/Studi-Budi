using ChatServer;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Teacher
{
    public class TeacherActivity : ITeacherActivity
    {
        private StudiBudiContext _context;
        public TeacherActivity(StudiBudiContext context)
        {
            _context = context;
        }

        public void AddSubject(int teacherID, int subjectID)
        {
            _context.Teaching.Add(new Teaching() { Userid = teacherID, Subjectid = subjectID });
             _context.SaveChanges();
        }

        //creates request to admin for adding new custom subject
        public void AddSubject(int teacherID, string title)
        {
            _context.SubjectRequest.Add(new SubjectRequest {UserID = teacherID, Title = title });
            _context.SaveChanges();
        }

        public async Task DeleteSubject(int teacherID, string subjectTitle)
        {
            int subjectID = await _context.Subject.Where(s => s.Title.Equals(subjectTitle)).Select(s => s.Subjectid).FirstOrDefaultAsync();
            Teaching teaching = await _context.Teaching.Where(t => t.Userid == teacherID && t.Subjectid == subjectID).FirstOrDefaultAsync();
            _context.Remove(teaching);
            await _context.SaveChangesAsync();
        }

        //get subjects titles that is not taken already
        public async Task<List<Subject>> GetAvailableSubjects(int teacherID)
        {
            List<Subject> subjects = await _context.Subject.ToListAsync();

            Func<int, List<Teaching>> getTeachingsByID = delegate (int teacherID)
            {
                return _context.Teaching.Where(t => t.Userid == teacherID).ToList();
            };

            List<Teaching> teachings = getTeachingsByID(teacherID);
            List<Subject> takenSubjects = teachings.Select(t => GetSubjectByID(t.Subjectid)).ToList();


            foreach(Subject item in takenSubjects)
            {
                subjects.Remove(item);
            }

            return subjects;
        }

        public async Task<List<string>> GetMySubjects(int teacherID)
        {
            IList<Teaching> teachings = await _context.Teaching.ToListAsync();
            IList<Subject> subjects = await _context.Subject.ToListAsync();

            List<string> mySubjects = (from t in teachings
                          join s in subjects on t.Subjectid equals s.Subjectid
                          where t.Userid == teacherID
                          select s.Title).ToList();

            return mySubjects;
        }

        public void ReportStudent(string studentName, string message)
        {
            _context.Report.Add(new Report {UserID = GetUserIdByName(studentName), Message = message});
            _context.SaveChanges();
        }

        public async Task Share(int teacherID, string subjectTitle, string question, string answer)
        {
            if (string.IsNullOrEmpty(subjectTitle))
            {
                throw new ArgumentException("subject cannot be empty");
            }

            if (string.IsNullOrEmpty(question))
            {
                throw new ArgumentException("question cannot be empty");
            }

            if (string.IsNullOrEmpty(answer))
            {
                throw new ArgumentException("answer cannot be empty");
            }

            int answeredCount = GetAnsweredQuestionsCount(teacherID, subjectTitle);
            int points = GetPoints(teacherID, subjectTitle);

            _context.FAQ.Add(new FAQ { TeacherID = teacherID, Question = question, Answer = answer, Points = points, 
                Answered = answeredCount, SubjectID = GetSubjectIdByTitle(subjectTitle)});
            await _context.SaveChangesAsync();
        }

        private int GetAnsweredQuestionsCount(int teacherID, string subjecTitle)
        {
            return _context.Question.Where(q => q.TeacherName == GetUserNamedByID(teacherID) && q.Status == 1 && q.SubjectTitle == subjecTitle).Count();
        }

        private int GetPoints(int teacherID, string subjecTitle)
        {
            return _context.Question.Where(q => q.TeacherName == GetUserNamedByID(teacherID) && q.Status == 1 && q.SubjectTitle == subjecTitle).Sum(q => q.Points);
        }

        private Subject GetSubjectByID(int id)
        {
            return _context.Subject.Where(s => s.Subjectid == id).FirstOrDefault();
        }

        private int GetSubjectIdByTitle(string title)
        {
            return _context.Subject.Where(s => s.Title == title).Select(s => s.Subjectid).FirstOrDefault();
        }

        private int GetUserIdByName(string name)
        {
            return _context.User.Where(u => u.Nick.Equals(Encryptor.Encrypt(name))).Select(u => u.Userid).FirstOrDefault();
        }
        private string GetUserNamedByID(int id)
        {
            return _context.User.Where(u => u.Userid == id).Select(u => u.Nick).FirstOrDefault();
        }
    }
}
