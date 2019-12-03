using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic.Admin;
using StudyBuddy.Web.RazorPages.Logic.Entities;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Pages.AdminPage
{
    public class ReportsModel : PageModel
    {
        //services
        private IReportsLoader _reportsLoader;
        private IAdminActivity _adminActivity;

        //properties
        public IList<Report> Reports { get; set; }
        public IList<ReportedUser> ReportedUsers { get; set; }
        public string Now { get; set; }

        //properties for user banning
        [PageRemote(
            ErrorMessage = "Date is already gone.",
            AdditionalFields = "__RequestVerificationToken",
            HttpMethod = "post",
            PageHandler = "CheckDate"
        )]
        [BindProperty]
        public DateTime DateForBan { get; set; }

        [BindProperty]
        public int UserID { get; set; }

        public ReportsModel(IReportsLoader reportsLoader, IAdminActivity adminActivity)
        {
            _reportsLoader = reportsLoader;
            _adminActivity = adminActivity;
        }

        public async Task OnGet()
        {
            Reports = await _reportsLoader.GetReports();
            ReportedUsers = await _adminActivity.GetReportedUsers();
            Now = DateTime.Now.Date.ToShortDateString();
        }

        public IActionResult OnPost(int userID)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _adminActivity.SuspendUser(userID, DateForBan);
            return RedirectToPage("/AdminPage/Reports");
        }

        public async Task<IActionResult> OnPostCancelAsync(int userID)
        {
            await _adminActivity.CancelBan(userID);
            return RedirectToPage("/AdminPage/Reports");
        }

        public async Task<IActionResult> OnPostDeleteAsync(int reportID)
        {
            await _adminActivity.DeleteReport(reportID);
            return RedirectToPage("/AdminPage/Reports");
        }

        public JsonResult OnPostCheckDate()
        {
            var valid = DateForBan > DateTime.Now.Date;
            return new JsonResult(valid);
        }
    }
}
