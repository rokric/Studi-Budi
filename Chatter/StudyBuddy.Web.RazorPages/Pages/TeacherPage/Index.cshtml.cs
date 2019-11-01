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

        public IndexModel(StudiBudiContext context)
        {
            _context = context;
        }

        public IList<User> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.User.ToListAsync();
        }
    }
}
