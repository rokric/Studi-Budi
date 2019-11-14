using Microsoft.EntityFrameworkCore;
using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Data
{
    public interface IStudiBudiContext
    {
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Teaching> Teaching { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Question> Question { get; set; }
        public DbSet<Points> Point { get; set;  }
    }
}
