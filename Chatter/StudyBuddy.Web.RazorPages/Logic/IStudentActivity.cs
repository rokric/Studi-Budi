using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public interface IStudentActivity
    {
        Task<List<string>> GetSubjectsTitles();
        Task<List<Models.TeacherAndSubject>> GetTeachersAndSubjects();
        List<Models.TeacherAndSubject> FilterTeachersAndSubjects(string filter, List<Models.TeacherAndSubject> teachersAndSubjects);
    }
}
