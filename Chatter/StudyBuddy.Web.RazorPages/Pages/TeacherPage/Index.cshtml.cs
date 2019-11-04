using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.TeacherPage
{
    public class IndexModel : PageModel
    {
        private readonly StudiBudiContext _context;
        private int teacherID = 3;

        public IndexModel(StudiBudiContext context)
        {
            _context = context;
        }

        public string TeacherName { get; private set; }

        public async Task OnGetAsync()
        {
            IList<User> teachers = await _context.User.Where(user => user.Profession.Equals("teacher")).ToListAsync();
            TeacherName = (from t in teachers
                          where t.Userid == teacherID
                          select t.Nick).FirstOrDefault();

            TeacherName = StudyBuddyLogic.Encryptor.Decrypt(TeacherName);
        }
    }
}
