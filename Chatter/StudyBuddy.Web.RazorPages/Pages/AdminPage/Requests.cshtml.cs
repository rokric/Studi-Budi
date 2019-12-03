using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic.Admin;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.AdminPage
{
    public class RequestsModel : PageModel
    {
        private IAdminActivity _adminActivity;
        private IRequestLoader _requestLoader;

        public IList<SubjectRequest> Requests { get; set; }
        public IList<Subject> Subjects { get; set; }

        public string ErorrApprove { get; set; }

        public RequestsModel(IAdminActivity adminActivity, IRequestLoader requestLoader)
        {
            _adminActivity = adminActivity;
            _requestLoader = requestLoader;
        }

        public async Task<IActionResult> OnGetAsync(string message = "")
        {
            Subjects = await _requestLoader.GetSubjects();
            Requests = await _requestLoader.GetRequests();

            if(message != "")
            {
                ModelState.AddModelError("ErorrApprove", message);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostApproveAsync(int requestID)
        {
            try
            {
                await _adminActivity.ApproveNewSubjectRequest(requestID);
            }
            catch(ArgumentException exc)
            {
                ModelState.AddModelError("ErorrApprove", exc.Message);
                return RedirectToAction("OnGetAsync", new { message = exc.Message });
            }
            
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDenyAsync(int requestID)
        {
            await _adminActivity.DenyNewSubjectRequest(requestID);
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int subjectID)
        {
            await _adminActivity.DeleteSubject(subjectID);
            return RedirectToPage();
        }
    }
}
