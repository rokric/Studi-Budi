using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic
{
    public interface IDBManager
    {
        string GetUserNameByID(int id);
        Question FindQuestionById(int questionID);
    }
}
