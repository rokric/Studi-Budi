using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Logic.Entities;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Admin
{
    public class AdminActivity : IAdminActivity
    {
        private StudiBudiContext _context;
        public AdminActivity(StudiBudiContext context)
        {
            _context = context;
        }

        // adds new subject to Subject table if validation is passed
        public async Task ApproveNewSubjectRequest(int requestID)
        {
            SubjectRequest subjectRequest = await GetSubjectRequestByID(requestID);
            string message = "added";
            if (IsValidNewSubject(subjectRequest, ref message))
            {
                AddNewSubject(subjectRequest.Title);
                await DenyNewSubjectRequest(subjectRequest.ID);
            }
            else
            {
                throw new ArgumentException("request cannot be approved: " + message);
            }
        }

        //deletes request if it is denied
        public async Task DenyNewSubjectRequest(int requestID)
        {
            _context.Remove(await GetSubjectRequestByID(requestID));
            _context.SaveChanges();
        }

        public void SuspendUser(int userID, DateTime until)
        {
            string message="";
            if (IsValidSuspension(until, ref message))
            {
                Ban ban = new Ban
                {
                    UserID = userID,
                    Until = until
                };

                _context.Add(ban);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("User cannot be banned: " + message);
            }
        }

        private bool IsValidSuspension(DateTime until, ref string message)
        {
            if(until.Date < DateTime.Now.Date)
            {
                message = "Date is not valid. It has already gone.";
                return false;
            }

            return true;
        }

        private bool IsValidNewSubject(SubjectRequest request, ref string message)
        {

            if (string.IsNullOrEmpty(request.Title))
            {
                message = "subject title cannot be empty.";
                return false;
            }

            if (CheckIfNewSubjectAlreadyExist(request.Title))
            {
                message = "subject already exist.";
                return false;
            }

            return true;
            
        }

        private bool CheckIfNewSubjectAlreadyExist(string title)
        {
            bool contains = _context.Subject.Any(s => s.Title.ToLower() == title.ToLower());
            return contains;
        }

        private async Task<SubjectRequest> GetSubjectRequestByID(int subjectRequestID)
        {
            return await _context.SubjectRequest.Where(s => s.ID == subjectRequestID).FirstOrDefaultAsync();
        }

        private void AddNewSubject(string title)
        {
            _context.Add(new Subject { Title = title });
            _context.SaveChanges();
        }

        //gets reported users and checks if user is already banned
        public async Task<List<ReportedUser>> GetReportedUsers()
        {
            List<int> reportedUsersID = await _context.Report.Select(r => r.UserID).Distinct().ToListAsync();
            List<int> bannedUsersID = await _context.Ban.Select(b => b.UserID).Distinct().ToListAsync();

            List<ReportedUser> reportedUsers = new List<ReportedUser>();

            foreach(var reportedUser in reportedUsersID)
            {
                if (bannedUsersID.Contains(reportedUser))
                {
                    reportedUsers.Add(new ReportedUser
                    {
                        UserID = reportedUser,
                        Banned = true
                    });

                    bannedUsersID.Remove(reportedUser);
                }
                else
                {
                    reportedUsers.Add(new ReportedUser
                    {
                        UserID = reportedUser,
                        Banned = false
                    });
                }
            }

            foreach(var bannedUser in bannedUsersID)
            {
                reportedUsers.Add(new ReportedUser
                {
                    UserID = bannedUser,
                    Banned = true
                });
            }
                
            /*List<ReportedUser> reportedUsers = reports.GroupJoin(bans, report => report.UserID,
                ban => ban.UserID,
                (report, ban) => new ReportedUser
                {
                    UserID = report.UserID,
                    Banned = true

                }).DefaultIfEmpty(new ReportedUser
                {
                    UserID = 
                    Banned = false

                }).ToList();

            foreach(var item in reportedUsers)
            {
                Console.WriteLine(item.UserID);
                Console.WriteLine(item.Banned);
            }*/

            return reportedUsers;
        }

        public async Task CancelBan(int userID)
        {
            Ban ban = await _context.Ban.Where(b => b.UserID == userID).FirstOrDefaultAsync();
            _context.Remove(ban);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReport(int reportID)
        {
            Report report = await _context.Report.Where(r => r.ID == reportID).FirstOrDefaultAsync();
            _context.Remove(report);
            await _context.SaveChangesAsync();
        }
    }
}
