using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Models
{
    public class Report
    {
        public int ID { get; set; }
        public int UserID { get; set; }

        [DataType(DataType.Date)]
        public DateTime Until { get; set; }
        public string Message { get; set; }
    }
}
