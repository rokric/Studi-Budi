using StudyBuddy.Web.RazorPages.Logic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Admin
{
    public interface IAdminActivity
    {
        void SuspendUser(int userID, DateTime until);
        Task ApproveNewSubjectRequest(int requestID);
        Task DenyNewSubjectRequest(int requestID);
        Task<List<ReportedUser>> GetReportedUsers();
        Task CancelBan(int userID);
        Task DeleteReport(int reportID);
    }
}
