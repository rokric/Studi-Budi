using StudyBuddy.Web.RazorPages.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public interface IStudentActivity
    {
        Task<List<string>> GetSubjectsTitles();
        Task<List<TeacherAndSubject>> GetTeachersAndSubjects();
        List<TeacherAndSubject> FilterTeachersAndSubjects(string filter, List<TeacherAndSubject> teachersAndSubjects);

        //return FAQ (teacherID is replaced by teacher name)
        Task<List<StudentFAQ>> GetFAQs();
    }
}
