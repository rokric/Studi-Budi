using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic.Admin;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.AdminPage
{
    public class AddModel : PageModel
    {
        private IAdminActivity _adminActivity;

        [BindProperty]
        public string Title { get; set; }

        public string ErrorAdd { get; set; }

        public AddModel(IAdminActivity adminActivity)
        {
            _adminActivity = adminActivity;
        }

        public IActionResult OnPost()
        {
            try
            {
                _adminActivity.AddSubject(Title);
                return RedirectToPage("/AdminPage/Requests");
            }
            catch(ArgumentException exc)
            {
                ModelState.AddModelError("ErrorAdd", exc.Message);
                return Page();
            }
        }
    }
}
