using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Data;
using StudyBuddy.Web.RazorPages.Models;

namespace StudyBuddy.Web.RazorPages.Logic.Admin
{
    public class ReportsLoader : IReportsLoader
    {
        private StudiBudiContext context;

        public ReportsLoader(StudiBudiContext context)
        {
            this.context = context;
        }

        public async Task<List<Report>> GetReports()
        {
           return await context.Report.ToListAsync();
        }
    }
}
