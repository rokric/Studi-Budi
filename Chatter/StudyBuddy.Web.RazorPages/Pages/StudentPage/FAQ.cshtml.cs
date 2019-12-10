using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StudyBuddy.Web.RazorPages.Logic;
using StudyBuddy.Web.RazorPages.Logic.Entities;

namespace StudyBuddy.Web.RazorPages.Pages.StudentPage
{
    public class FAQModel : PageModel
    {
        private IStudentActivity _studentActivity;
        public bool All { get; set; }

        public List<StudentFAQ> StudentFAQs { get; set; }
        public FAQModel(IStudentActivity studentActivity)
        {
            _studentActivity = studentActivity;
        }
        public async Task OnGet(bool all = false)
        {
            StudentFAQs = await _studentActivity.GetFAQs(all);
            All = all;
        }

        public IActionResult OnPostViewMoreAsync()
        {
            return RedirectToAction("OnGet()", new { all = true });
        }
    }
}