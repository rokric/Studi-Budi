using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
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
                Suspension suspension = new Suspension
                {
                    UserID = userID,
                    Until = until
                };

                _context.Add(suspension);
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
    }
}
