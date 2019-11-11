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
                List<Teaching> Teachings = _context.Teaching.Where(t => t.Subjectid == GetSubjectIdByTitle(filter)).ToList();

                teachersAndSubjects = Teachings.Select(t => new TeacherAndSubject
                {
                    TeacherName = GetTeacherNameById(t.Userid),
                    SubjectTitle = filter
                }).ToList();
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
            List<Models.Teaching> teachings = await _context.Teaching.ToListAsync();

            List <TeacherAndSubject> teachersAndSubjects = teachings.Select(t => new TeacherAndSubject
            {
                TeacherName = GetTeacherNameById(t.Userid),
                SubjectTitle = GetSubjectTitleById(t.Subjectid)
            }).ToList();

            return teachersAndSubjects;
        }
    }
}
