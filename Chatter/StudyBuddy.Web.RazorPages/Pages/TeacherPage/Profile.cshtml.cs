using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class ProfileModel : PageModel
    {
        private readonly StudyBuddy.Web.RazorPages.Data.StudiBudiContext _context;

        public ProfileModel(StudyBuddy.Web.RazorPages.Data.StudiBudiContext context)
        {
            _context = context;
        }

        //todo: teacher id is hardcoded but it should be received after user logs in
        private int teacherID = 3;
        public List<string> MySubjects;

        public async Task OnGetAsync()
        {
            IList<Teaching> teachings = await _context.Teaching.ToListAsync();
            IList<Subject> subjects = await _context.Subject.ToListAsync();

            MySubjects = (from t in teachings
                         join s in subjects on t.Subjectid equals s.Subjectid
                         where t.Userid == teacherID
                         select s.Title).ToList();
        }
    }
}
