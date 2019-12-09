using StudyBuddy.Web.RazorPages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudyBuddy.Web.RazorPages.Logic.Profile
{
    public interface IProfile
    {
        bool IsPasswordMaches(string password, int id);
        public string GetPasswordByID(int ID);
        Task PasswordChange( string New, int Id);
         Task NameChange(string New, int Id);
        public bool IsStringGood(string password);
        public string GetProfesionByID(int ID);
        public bool IsStringsMaches(string password, string password2);

        

    }
}
