using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Teacher
{
    public interface ITeacherActivity
    {
        Task<List<Subject>> GetAvailableSubjects(int teacherID);
        void AddSubject(int teacherID, int subjectID);
        void AddSubject(int teacherID, string title);

        Task<List<string>> GetMySubjects(int teacherID);

        Task DeleteSubject(int teacherID, string subjectTitle);

        void ReportStudent(string studentName, string message);
    }
}
