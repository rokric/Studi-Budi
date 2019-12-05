using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Entities
{
    public struct ReportedUser
    {
        public int UserID { get; set; }
        public string Since { get; set; }
        public bool Banned { get; set; }
    }
}
