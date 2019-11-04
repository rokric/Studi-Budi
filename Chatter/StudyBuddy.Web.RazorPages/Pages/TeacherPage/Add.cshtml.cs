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
    public class AddModel : PageModel
    {
        private readonly StudyBuddy.Web.RazorPages.Data.StudiBudiContext _context;

        [BindProperty]
        public int SubjectID { get; set; }
        public List<SelectListItem> Options { get; set; }

        public AddModel(StudyBuddy.Web.RazorPages.Data.StudiBudiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGetAsync()
        {
            Options = await _context.Subject.Select(s =>
                                                 new SelectListItem
                                                 {
                                                     Value = s.Subjectid.ToString(),
                                                     Text = s.Title
                                                 }).ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int teacherID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if(!_context.Teaching.Any(t => t.Userid == teacherID && t.Subjectid == SubjectID))
            {
                _context.Teaching.Add(new Teaching() { Userid = teacherID, Subjectid = SubjectID });
                await _context.SaveChangesAsync();
                return RedirectToPage("./Subjects");
            }

            return Content("Subject already exist!");
        }
    }
}
