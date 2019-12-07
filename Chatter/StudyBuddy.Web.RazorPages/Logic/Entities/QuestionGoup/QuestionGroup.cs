using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Entities
{
    public class QuestionGroup
    {
        public QuestionGroupKey Key { get; set; }
        public List<Question> Questions { get; set; }
    }
}
