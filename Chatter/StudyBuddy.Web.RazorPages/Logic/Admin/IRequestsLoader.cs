using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Admin
{
    public interface IRequestLoader
    {
        Task<List<SubjectRequest>> GetRequests();
        Task<List<Subject>> GetSubjects();
    }
}
