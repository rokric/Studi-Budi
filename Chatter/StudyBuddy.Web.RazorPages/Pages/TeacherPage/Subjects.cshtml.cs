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
    public class SubjectsModel : PageModel
    {
        private readonly StudyBuddy.Web.RazorPages.Data.StudiBudiContext _context;

        public SubjectsModel(StudyBuddy.Web.RazorPages.Data.StudiBudiContext context)
        {
            _context = context;
        }

        //todo: teacher id is hardcoded but it should be received after user logs in
        public int TeacherID = 3;
        public List<string> MySubjects = new List<string>();

        public async Task OnGetAsync()
        {
            IList<Teaching> teachings = await _context.Teaching.ToListAsync();
            IList<Subject> subjects = await _context.Subject.ToListAsync();

            MySubjects = (from t in teachings
                         join s in subjects on t.Subjectid equals s.Subjectid
                         where t.Userid == TeacherID
                          select s.Title).ToList();
        }

        public async Task<IActionResult> OnPostDeleteAsync(string subjectTitle)
        {
            int subjectID = await _context.Subject.Where(s => s.Title.Equals(subjectTitle)).Select(s => s.Subjectid).FirstOrDefaultAsync();
            Teaching teaching = await _context.Teaching.Where(t => t.Userid == TeacherID && t.Subjectid == subjectID).FirstOrDefaultAsync();
            _context.Remove(teaching);
            await _context.SaveChangesAsync();
            return Redirect("/TeacherPage/Subjects");
        }
    }
}
