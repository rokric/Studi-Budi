using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Admin
{
    public class RequestsLoader : IRequestLoader
    {
        private StudiBudiContext context;

        public RequestsLoader(StudiBudiContext context)
        {
            this.context = context;
        }

        public async Task<List<SubjectRequest>> GetRequests()
        {
            return await context.SubjectRequest.ToListAsync();
        }

        public async Task<List<Subject>> GetSubjects()
        {
            return await context.Subject.ToListAsync();
        }
    }
}
