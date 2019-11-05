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
    public class TeacherProfileModel : PageModel
    {
        private readonly StudyBuddy.Web.RazorPages.Data.StudiBudiContext _context;

        public TeacherProfileModel(StudyBuddy.Web.RazorPages.Data.StudiBudiContext context)
        {
            _context = context;
        }

        public void OnGet()
        {

        }
    }
}
