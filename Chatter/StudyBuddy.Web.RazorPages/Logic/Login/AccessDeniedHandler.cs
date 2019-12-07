using StudyBuddy.Web.RazorPages.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public class AccessDeniedHandler : IAccessDeniedHandler
    {
        private StudiBudiContext context;

        public AccessDeniedHandler(StudiBudiContext context)
        {
            this.context = context;
        }

        public bool IsAccessDenied(int userID)
        {
            return context.Ban.Where(b => b.UserID == userID).FirstOrDefault() == null ? false : true;
        }
    }
}
