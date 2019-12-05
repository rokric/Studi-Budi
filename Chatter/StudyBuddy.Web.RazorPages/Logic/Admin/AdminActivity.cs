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
            await _context.SaveChangesAsync();
        }

        public void SuspendUser(int userID, DateTime since)
        {
            Ban ban = new Ban
            {
                UserID = userID,
                Until = since
            };

            _context.Add(ban);
            _context.SaveChanges();
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
                message = "subject already exists.";
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
            List<Report> reports = await _context.Report.ToListAsync();
            List<Ban> bans = await _context.Ban.ToListAsync();
            List<ReportedUser> reportedUsers = new List<ReportedUser>();

            reportedUsers = reports.GroupJoin(bans, r => r.UserID, b => b.UserID,
                (r, reported) => reported.Select(b => new ReportedUser
                {
                    UserID = r.UserID,
                    Banned = true,
                    Since = b.Until.ToShortDateString()
                }).DefaultIfEmpty(new ReportedUser
                {
                    UserID = r.UserID,
                    Banned = false,
                    Since = DateTime.Now.ToShortDateString()
                })).SelectMany(e => e.Select(x => x)).GroupBy(e => e.UserID).Select(x => x.First()).ToList();

            foreach(var item in reportedUsers)
            {
                Console.WriteLine(item.UserID + " " + item.Banned + " " + item.Since);
            }

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

        public async Task DeleteSubject(int subjectID)
        {
            await DeleteTeachings(subjectID);

            Subject subject = await _context.Subject.Where(r => r.Subjectid == subjectID).FirstOrDefaultAsync();
            _context.Remove(subject);
            await _context.SaveChangesAsync();
        }

        //delete all related teachings after removing subject
        private async Task DeleteTeachings(int subjectID)
        {
            List<Teaching> teachingsToRemove = await _context.Teaching.Where(t => t.Subjectid == subjectID).ToListAsync();
            _context.RemoveRange(teachingsToRemove);
            await _context.SaveChangesAsync();
        }

        //admin adds new subject to database
        public void AddSubject(string title)
        {
            string message = "";
            if (IsValidNewSubject(new SubjectRequest { Title = title }, ref message))
            {
                AddNewSubject(title);
            }
            else
            {
                throw new ArgumentException(message);
            }
        }
    }
}
